using ContactListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Data
{
    public class ContactListDataContext : DbContext
    {
        public ContactListDataContext(DbContextOptions<ContactListDataContext> options) : base(options)
        {
     
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO: Constrains
            modelBuilder.Entity<Contact>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
