using Application.Repositories;
using Core.DataAccess;
using Core.Paging;
using FileUploadSystem.Domain.Entities;
using FileUploadSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, FileUploadDbContext>, IUserRepository
    {
        public UserRepository(FileUploadDbContext context) : base(context)
        {
        }
    }
}
