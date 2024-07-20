using FileUploadSystem.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Application.Repositories;
using Persistence.Repositories;

namespace FileUploadSystem.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            // DbContext'i ekleyin
            services.AddDbContext<FileUploadDbContext>();

            // Scoped servisleri ekleyin
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IUploadedFileRepository, UploadedFileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISharedFileRepository, SharedFileRepository>();
        }
    }
}
