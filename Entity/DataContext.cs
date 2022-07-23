using Microsoft.EntityFrameworkCore;
using WebTatIntek.Models;

namespace WebTatIntek.Entity
{
    public class DataContext : DbContext
    {
        public DbSet<UsersNotes> UsersNotes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Notes> Notes { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            Database.EnsureCreated();   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersNotes>().HasData(
                    new UsersNotes { Id = 1, NoteId = 1, UserId = 1 },
                    new UsersNotes { Id = 2, NoteId = 2, UserId = 1 },
                    new UsersNotes { Id = 3, NoteId = 3, UserId = 1 }
            );

            modelBuilder.Entity<Users>().HasData(
                    new Users { UserId = 1, FirstName = "Иван", LastName = "Иванов", Login = "ivanov", Password = "ivanov" }
            );

            modelBuilder.Entity<Notes>().HasData(
                    new Notes { NoteId = 1, Title = "Заметка №1", Description = "Описание заметки №1" },
                    new Notes { NoteId = 2, Title = "Заметка №2", Description = "Описание заметки №2" },
                    new Notes { NoteId = 3, Title = "Заметка №3", Description = "Описание заметки №3" }
            );

        }
    }
}
