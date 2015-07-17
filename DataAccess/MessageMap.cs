using System.Data.Entity.ModelConfiguration;
using DataAccess.EntityModel;

namespace DataAccess
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            HasKey(k => k.MessageId);

            ToTable("Message");

            Property(k => k.MessageId).HasColumnName("MessageId");
            Property(k => k.Title).HasColumnName("Message").HasMaxLength(256);
        }
    }
}
