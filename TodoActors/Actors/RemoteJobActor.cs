using Akka.Actor;

namespace Actors.Actors
{
    /// <summary>
    /// Remote-deployed actor designed to help forward jobs to the remote hosts
    /// </summary>
    public class RemoteJobActor : ReceiveActor
    {
        public RemoteJobActor()
        {
            Receive<IMessageCommand>(start =>
            {
                Context.ActorSelection("/user/api").Tell(start, Sender);
            });
        }
    }
}
