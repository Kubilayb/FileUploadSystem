using Microsoft.EntityFrameworkCore;
using FileUploadSystem.Domain.Entities;

namespace FileUploadSystem.Persistence.Context
{
    public class FileUploadDbContext : DbContext
    {
        public FileUploadDbContext(DbContextOptions<FileUploadDbContext> options) : base(options)
        {
        }

        public DbSet<File> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FileShare> FileShares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>()
                .Property(f => f.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<FileShare>()
                .Property(fs => fs.Id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<FileShare>()
                .HasOne(fs => fs.File)
                .WithMany()
                .HasForeignKey(fs => fs.FileId);

            modelBuilder.Entity<FileShare>()
                .HasOne(fs => fs.User)
                .WithMany()
                .HasForeignKey(fs => fs.UserId);
        }
    }
}
