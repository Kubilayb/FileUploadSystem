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
    public class SharedFileRepository : IRepository<SharedFile>
    {
        private readonly FileUploadDbContext _context;

        public SharedFileRepository(FileUploadDbContext context)
        {
            _context = context;
        }

        public void Add(SharedFile entity)
        {
            _context.SharedFiles.Add(entity);
        }

        public void Delete(SharedFile entity)
        {
            _context.SharedFiles.Remove(entity);
        }

        public void SoftDelete(SharedFile entity)
        {
            entity.IsDeleted = true; // Assuming you have a soft delete mechanism
            _context.SharedFiles.Update(entity);
        }

        public SharedFile? Get(Expression<Func<SharedFile, bool>> predicate, Func<IQueryable<SharedFile>, IIncludableQueryable<SharedFile, object>>? include = null)
        {
            var query = _context.SharedFiles.AsQueryable();
            if (include != null)
            {
                query = include(query);
            }
            return query.FirstOrDefault(predicate);
        }

        public IPaginate<SharedFile> GetList(Expression<Func<SharedFile, bool>>? predicate = null, Func<IQueryable<SharedFile>, IIncludableQueryable<SharedFile, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true)
        {
            var query = _context.SharedFiles.AsQueryable();
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

        public void Update(SharedFile entity)
        {
            _context.SharedFiles.Update(entity);
        }

        public IQueryable<SharedFile> Query()
        {
            return _context.SharedFiles.AsQueryable();
        }
    }
}
