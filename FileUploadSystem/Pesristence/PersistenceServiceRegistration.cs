using FileUploadSystem.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;
using Persistence.Repositories;

namespace FileUploadSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, string connectionString)
        {
            // DbContext'i ekleyin
            services.AddDbContext<FileUploadDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Scoped servisleri ekleyin
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IUploadedFileRepository, UploadedFileRepository>();
            services.AddScoped<IUserRepository, UserRepository>(); 
            services.AddScoped<ISharedFileRepository, SharedFileRepository>();
        }
    }
}
