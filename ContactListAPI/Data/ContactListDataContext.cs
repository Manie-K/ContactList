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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure the relationship between categories
            modelBuilder.Entity<Subcategory>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            //Populate categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Służbowy", AllowCustomSubcategory = false },
                new Category { Id = 2, Name = "Prywatny", AllowCustomSubcategory = false },
                new Category { Id = 3, Name = "Inny", AllowCustomSubcategory = true }
            );

            //Populate subcategories
            modelBuilder.Entity<Subcategory>().HasData(
                new Subcategory { Id = 1, Name = "Szef", CategoryId = 1 },
                new Subcategory { Id = 2, Name = "Klient", CategoryId = 1 },
                new Subcategory { Id = 3, Name = "Współpracownik", CategoryId = 1 }
            );


            //Constrains
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

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Subcategory>()
                .HasKey(c => c.Id);
        }
    }
}
