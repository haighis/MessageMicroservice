using System.Data.Entity;
using DataAccess.EntityModel;

namespace DataAccess
{
    public class MessageDbContext : DbContext
    {
        static MessageDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MessageDbContext>());
        }

        public MessageDbContext()
            : this("Name=MessageSample")
        {
            
        }

        public MessageDbContext(string connectionstringName) : base(connectionstringName)
        {  
            Configuration.LazyLoadingEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Message> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MessageMap());
        }
    }
}
