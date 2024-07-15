using FileUploadSystem.Persistence.Contexts;
using FileUploadSystem.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;
using Persistence.Repositories;
using Application.Services.SharedFileService;
using Application.Services.UploadedFileService;

namespace FileUploadSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, string connectionString)
        {
            // Add DbContext with connection string
            services.AddDbContext<FileUploadDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add scoped services
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IUploadedFileRepository, UploadedFileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISharedFileRepository, SharedFileRepository>();

            services.AddScoped<ISharedFileService, SharedFileService>();
            services.AddScoped<IUploadedFileService, UploadedFileService>();
        }
    }
}
