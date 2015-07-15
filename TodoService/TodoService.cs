using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using System;
using TodoDataAccess.DataAccess;
using TodoDataAccess.DataModel;
using TodoDataModel;

namespace TodoService
{
    public interface ITodoServiceBusinessLogic : IDisposable
    {
        Task AddTodoAsync(string taskName);

        void AddTodo(string taskName);

        bool CanAddTodo(string taskName);
    }

    public class TodoServiceBusinessLogic : ITodoServiceBusinessLogic
    {
        private readonly TodoDbContext _dbContext;
        
        public TodoServiceBusinessLogic()
        {
            _dbContext = new TodoDbContext();
        }

        public TodoServiceBusinessLogic(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TodoServiceBusinessLogic(string connectionStringName)
        {
            _dbContext = new TodoDbContext(connectionStringName);
        }

        public void AddTodo(string taskName)
        {
            try
            {   
                // TODO
                // add validator's for the data to validate date is correct before save. 
                // If incorrect throw new business exception that validation failed. restart actor with 3 retries.
                _dbContext.Todos.Add(new Todo { TaskName = taskName });
                _dbContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                throw new UnknownTodoException(ex.Message,ex);
            }
        }

        public async Task AddTodoAsync(string taskName)
        {
             try
            {
                _dbContext.Todos.Add(new Todo { TaskName = taskName });
                await _dbContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                throw new UnknownTodoException(ex.Message,ex);
            }
        }

        public bool CanAddTodo(string taskName)
        {
            try
            {
                // TODO
                // add validator's for the data to validate date is correct before save. 
                // If incorrect throw new business exception that validation failed. restart actor with 3 retries.
                //_dbContext.Todos.Add(new Todo { TaskName = taskName });
                //_dbContext.SaveChanges();
                throw new Exception("devastation");
                return true;
            }
            catch (SqlException ex)
            {
                throw new UnknownTodoException(ex.Message, ex);
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
