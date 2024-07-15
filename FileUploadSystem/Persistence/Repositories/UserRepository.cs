using Application.Repositories;
using Core.DataAccess;
using FileUploadSystem.Domain.Entities;
using FileUploadSystem.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, FileUploadDbContext>, IUserRepository
    {
        public UserRepository(FileUploadDbContext context) : base(context)
        {
        }
    }
}
