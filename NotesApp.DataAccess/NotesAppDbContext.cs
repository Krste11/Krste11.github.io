using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Enums;
using NotesApp.Domain.Models;

namespace NotesApp.DataAccess
{
    public class NotesAppDbContext : DbContext
    {
        public NotesAppDbContext(DbContextOptions<NotesAppDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Note 

            modelBuilder.Entity<Note>()
                .Property(x => x.Text)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Note>()
                .Property(x => x.Priority)
                .IsRequired();

            modelBuilder.Entity<Note>()
                .Property(x => x.Tag)
                .IsRequired();

            modelBuilder.Entity<Note>()
                .HasOne(x => x.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.UserId);

            #endregion

            #region User

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasMaxLength(30)
                .IsRequired();

            #endregion

            #region Seed Data

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Username = "johndoe",
                    Password = "12345"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Username = "janesmith",
                    Password = "54321"
                }
            );

            modelBuilder.Entity<Note>().HasData(
                new Note
                {
                    Id = 1,
                    Text = "Finish the project report",
                    Priority = Priority.High,
                    Tag = Tag.Work,
                    UserId = 1
                },
                new Note
                {
                    Id = 2,
                    Text = "Go to the gym",
                    Priority = Priority.Medium,
                    Tag = Tag.Health,
                    UserId = 1
                },
                new Note
                {
                    Id = 3,
                    Text = "Call friends for dinner",
                    Priority = Priority.Low,
                    Tag = Tag.SocialLife,
                    UserId = 2
                }
            );

            #endregion
        }
    }
}
