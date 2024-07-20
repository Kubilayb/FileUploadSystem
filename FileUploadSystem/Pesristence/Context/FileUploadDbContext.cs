using Core.Entities;
using FileUploadSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileUploadSystem.Persistence.Contexts
{
    public class FileUploadDbContext : DbContext
    {
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SharedFile> SharedFiles { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=FileUploadSystemDB;User Id=sa;Password=YourStrongPassword123!;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
