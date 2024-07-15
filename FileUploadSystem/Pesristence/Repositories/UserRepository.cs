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
    public class UserRepository : IRepository<User>
    {
        private readonly FileUploadDbContext _context;

        public UserRepository(FileUploadDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
        }

        public void SoftDelete(User entity)
        {
            entity.IsDeleted = true; // Assuming you have a soft delete mechanism
            _context.Users.Update(entity);
        }

        public User? Get(Expression<Func<User, bool>> predicate, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null)
        {
            var query = _context.Users.AsQueryable();
            if (include != null)
            {
                query = include(query);
            }
            return query.FirstOrDefault(predicate);
        }

        public IPaginate<User> GetList(Expression<Func<User, bool>>? predicate = null, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
        {
            var query = _context.Users.AsQueryable();
            if (include != null)
            {
                query = include(query);
            }
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (!enableTracking)
            {
                query = query.AsNoTracking();
            }

            return query.ToPaginate(index, size);
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }

        public IQueryable<User> Query()
        {
            return _context.Users.AsQueryable();
        }
    }
}
