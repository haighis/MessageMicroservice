using System;
using Akka.Actor;
using Akka.Routing;
using TodoActors.Actors;
using TodoCommon;
using TodoDataModel;

namespace TodoActorService
{
    //TODO Does this need to be refactored to use IActorRef's instead of actor selection???
    public class TodosActorService
    {
        private readonly ActorSystem _actorSystem;

        public TodosActorService(ActorSystem actorSystem)
        {
            _actorSystem = actorSystem;
        }

        public void SendTodo(string taskName)
        {
            // send via actor selection
            //var todoCoordinator = _actorSystem.ActorSelection(ActorPaths.CoordinatorPath); 

            // Send via gorup router
            var todoCoordinator = _actorSystem.ActorOf(Props.Create(() => new TodoCoordinatorActor()).WithRouter(FromConfig.Instance), "todogroup");
            
            
            todoCoordinator.Tell(new Message(taskName, Guid.NewGuid()));
        }
    }
}
