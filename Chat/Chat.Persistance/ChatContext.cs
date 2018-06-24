namespace Chat.Persistance
{
    using Chat.Persistance.Models;
    using System.Data.Entity;

    public class ChatContext: DbContext
    {
        public ChatContext() : base("name=ChatModel")
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}