using Microsoft.EntityFrameworkCore;

namespace LibraryManagementProject.DataAccess
{
    public class LibraryDbContext :DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data to db
            modelBuilder.Entity<Book>().HasData(
                new Book { Id=2,Title = "C#", CreatedBy="Roopa",UpdatedBy="Roopa" },
                new Book { Id=3,Title = "Art of living", CreatedBy = "Suresh", UpdatedBy = "Suresh" },
                new Book { Id=4,Title = "Dora The Explorer", CreatedBy = "Swara", UpdatedBy = "Swara" },
                new Book { Id =5, Title = "Avarana", CreatedBy = "Santosh", UpdatedBy = "Santosh" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id=2,Name = "Alex",Email="alexander.com", CreatedBy = "Roopa", UpdatedBy = "Roopa" },
                new User { Id=3,Name = "Roopa",Email="roopasampagavi@gmail.com", CreatedBy = "Roopa", UpdatedBy = "Roopa" },
                new User { Id=4, Name = "Suresh", Email = "suresh.Raju@gmail.com",Status ="Active",Password= PasswordHelper.HashPassword("Password123"), CreatedBy = "Roopa", UpdatedBy = "Roopa" },
                new User { Id=5, Name = "Santosh", Email = "santosh.patil@gmail.com", Status = "Active", Password = PasswordHelper.HashPassword("swara@123"), CreatedBy = "Roopa", UpdatedBy = "Roopa" }
            );

            modelBuilder.Entity<Transaction>().HasData(
               new Transaction {Id=2, TransactionType = "Returned", BookId=2,UserId=2, CreatedBy = "Roopa", UpdatedBy = "Roopa" },
               new Transaction { Id=3,BookId = 3, UserId = 3,CreatedBy = "Roopa", UpdatedBy = "Roopa" }
           );
        }
    }
}
