using System.Data.Entity.ModelConfiguration;
using TodoDataAccess.DataModel;

namespace TodoDataAccess.DataAccess
{
    public class TodoMap : EntityTypeConfiguration<Todo>
    {
        public TodoMap()
        {
            HasKey(k => k.TodoId);

            ToTable("Todo");

            Property(k => k.TodoId).HasColumnName("TodoId");
            Property(k => k.TaskName).HasColumnName("TaskName").HasMaxLength(256);
        }
    }
}
