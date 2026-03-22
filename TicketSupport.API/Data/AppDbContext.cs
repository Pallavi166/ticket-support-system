using Microsoft.EntityFrameworkCore;
using TicketSupport.API.Models;


namespace TicketSupport.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TicketComment> TicketComments { get; set; }

        public DbSet<TicketStatusHistory> TicketStatusHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<TicketComment>()
            .HasKey(c => c.CommentId);
        }
    }
}

