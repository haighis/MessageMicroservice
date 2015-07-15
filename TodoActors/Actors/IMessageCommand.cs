using Akka.Actor;
using Akka.Routing;
using DataModel;

namespace Actors.Actors
{
    public interface IMessageCommand : IConsistentHashable
    {
        Message Message { get; }

        IActorRef Requestor { get; }
    }
}
