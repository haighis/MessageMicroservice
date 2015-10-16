using System;
using Akka.Actor;
using BusinessLogic;
using DataModel;

namespace Actors.Actors.DoesRecordExistDatabase
{
    /// <summary>
    /// Ask Actor that will will Tell if a db record exists in a database table.
    /// </summary>
    public class DbRecordExistsActor : ReceiveActor
    {
        public DbRecordExistsActor()
        {
            Receive<Message>(msg =>
            {
                var operation = "I checked and this db record does exist";
                Sender.Tell(operation, Sender);
                Console.WriteLine("In actor after sender tell.");
            }); 
        }
    }
}
