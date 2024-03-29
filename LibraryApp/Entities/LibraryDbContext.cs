using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace LibraryApp.Entities
{
    public class LibraryDbContext : IdentityDbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(b => b.Author)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(b => b.Genre)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(u => u.PublishedYear)
                    .IsRequired();

                entity.Property(b => b.Available)
                    .IsRequired();
            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.HasKey(bc => bc.Id);

                entity.HasOne(bc => bc.Book)
                      .WithMany(b => b.BookCopies)
                      .HasForeignKey(b => b.BookID);

                entity.Property(bc => bc.IsAvailable)
                    .IsRequired();
            });


            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.Property(l => l.LoanDate)
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(l => l.ReturnDate)
                    .IsRequired()
                    .HasColumnType("date");

                entity.HasOne(l => l.User)
                    .WithMany(u => u.Loans)
                    .HasForeignKey(l => l.UserID);


                entity.HasOne(l => l.BookCopy)
                    .WithMany(u => u.Loans)
                    .HasForeignKey(l => l.BookCopyID);
            });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MGODZICKI\\PRIVATE;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True");

            //optionsBuilder.UseLazyLoadingProxies();

        }
    }
}
