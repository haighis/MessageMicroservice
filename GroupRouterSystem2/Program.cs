using System.Linq;
using Actors.Actors.SupervisorStrategyPattern;
using Akka.Actor;
using Akka.Configuration;
using Akka.Configuration.Hocon;
using Akka.Routing;
using DataModel;
using System;
using System.Configuration;

namespace GroupRouterSystem
{
    internal class Program
    {

        private static Config _clusterConfig;
        private static IActorRef _testCoordinator;

        private static void Main(string[] args)
        {
            var section = (AkkaConfigurationSection)ConfigurationManager.GetSection("akka");
            _clusterConfig = section.AkkaConfig;
       //     LaunchBackend(new[] { "2551" });
            LaunchBackend(new[] { "2551" });
           // LaunchBackend(new string[0]);

            string input;

            Console.WriteLine("Enter send to send the message bar or quit to exit.");

            while ((input = Console.ReadLine()) != null)
            {
                var cmd = input;
                switch (cmd)
                {
                    case "quit":
                        return; // Stop the run thread
                    case "send":
                        // Send to backend which will write to the console
                        SendToBackend();

                        break;
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        /// <summary>
        /// Send to Backend. - Sample only. You wouldn't do this in production. Here an actor system is created each time
        /// this method is called which is an expensive operation.
        /// </summary>
        private static void SendToBackend()
        {
            if (_testCoordinator != null)
            {
                var routees = _testCoordinator.Ask<Routees>(new GetRoutees());
                Console.WriteLine("has routees" + routees.Result.Members.Any());

                _testCoordinator.Tell(new Message("this is a message from send to backend from system 2", Guid.NewGuid()));
                Console.WriteLine("path " + _testCoordinator.Path);
            }
        }

        private static void LaunchBackend(string[] args)
        {
            var port = args.Length > 0 ? args[0] : "0";

            var config = ConfigurationFactory.ParseString("akka.remote.helios.tcp.port=" + 0).WithFallback(_clusterConfig);
            
            var system = ActorSystem.Create("GroupRouterSystem", config);

            // Create Coordinator Actor that will supervise risky child (Character Actor) actor's
            //var actor = system.ActorOf(Props.Create(() => new CoordinatorActor()), "testcoordinator");

            ////// Send some messages to get gossip going
            //actor.Tell(new Message("test 2", Guid.NewGuid()));
            //actor.Tell(new Message("test 2", Guid.NewGuid()));
            //actor.Tell(new Message("test 2", Guid.NewGuid()));
            //actor.Tell(new Message("test 2", Guid.NewGuid()));

            if (_testCoordinator == null)
            {
                // WORKING config from code
                //var workers = new[] { "/user/testcoordinator" };
                //WORKING _testCoordinator = system.ActorOf(Props.Empty.WithRouter(new RandomGroup(workers)), "test-group");
                
                // hocon config
                _testCoordinator = system.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "test-group");
                Console.WriteLine("path " + _testCoordinator.Path);
                // Method #1 As found on http://getakka.net/docs/working-with-actors/Routers in ConsistentHashingGroup section of this page
             //   _testCoordinator = system.ActorOf(Props.Create(() => new CoordinatorActor()).WithRouter(FromConfig.Instance), "testcoordinator");
                //_testCoordinator = system.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "testgroup");
                //_testCoordinator = system.ActorOf(Props.Empty.WithRouter(new RandomGroup("/user/testcoordinator")), "testcoordinator");
            }

            //actor.Tell(new Message("warmup the system and get some gossip going 2", Guid.NewGuid()));
            //actor.Tell(new Message("warmup the system and get some gossip going 2", Guid.NewGuid()));
            //actor.Tell(new Message("warmup the system and get some gossip going 2", Guid.NewGuid()));
            //actor.Tell(new Message("warmup the system and get some gossip going 2", Guid.NewGuid()));
        }
    }
}


// var props = Props.Create<CoordinatorActor>().WithRouter(FromConfig.Instance);
// _testCoordinator = system.ActorOf(props, "todocoordinator");

//_testCoordinator = system.ActorOf(Props.Empty.WithRouter(new ConsistentHashingGroup("/user/testcoordinator")), "testcoordinator");

//_testCoordinator = system.ActorOf(Props.Create(() => new CoordinatorActor()).WithRouter(FromConfig.Instance), "testcoordinator");

//Console.WriteLine("path " + _testCoordinator.Path);

// Configure in code without hocon
//if (_testCoordinator == null)
//{
//    _testCoordinator = system.ActorOf(Props.Create(() => new CoordinatorActor()).WithRouter(
//    new ClusterRouterGroup(new ConsistentHashingGroup("/user/testcoordinator"),
//            new ClusterRouterGroupSettings(10, true, "program", ImmutableHashSet.Create("/user/testcoordinator"))
//                                )), "testcoordinator");
//}