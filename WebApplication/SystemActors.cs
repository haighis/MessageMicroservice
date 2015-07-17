using Akka.Actor;

namespace WebApplication
{
    public static class SystemActors
    {
        public static IActorRef TodoCoordinator = ActorRefs.Nobody;
    }
}