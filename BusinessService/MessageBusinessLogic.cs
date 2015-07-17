using System;
using System.Data.SqlClient;
using DataAccess;
using DataModel;
using Message = DataAccess.EntityModel.Message;

namespace BusinessLogic
{
    public interface IMessageBusinessLogic : IDisposable
    {
        void AddTodo(string title);
    }

    public class MessageBusinessLogic : IMessageBusinessLogic
    {
        private readonly MessageDbContext _dbContext;
        
        public MessageBusinessLogic()
        {
            _dbContext = new MessageDbContext();
        }

        public MessageBusinessLogic(MessageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MessageBusinessLogic(string connectionStringName)
        {
            _dbContext = new MessageDbContext(connectionStringName);
        }

        public void AddTodo(string title)
        {
            try
            {   
                // add validator's for the data to validate date is correct before save. 
                // If incorrect throw new business exception that validation failed. restart actor with 3 retries.

                var msg = new Message { Title = title };

                _dbContext.Todos.Add( msg );
                _dbContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new UnknownMessageException(ex.Message,ex);
            }
        }

        public void Dispose()
        {
            //if (_dbContext != null)
            //{
            //    _dbContext.Dispose();
            //}
        }
    }
}
