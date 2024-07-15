using System.Collections.Generic;
using System.Threading.Tasks;
using FileUploadSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Core.Paging;
using Application.Repositories;

namespace FileUploadSystem.Persistence.Repositories
{
    public class SharedFileRepository : ISharedFileRepository
    {
        private readonly AppDbContext _context;

        public SharedFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(SharedFile entity)
        {
            _context.SharedFiles.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(SharedFile entity)
        {
            await _context.SharedFiles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(SharedFile entity)
        {
            _context.SharedFiles.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(SharedFile entity)
        {
            _context.SharedFiles.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public SharedFile? Get(Expression<Func<SharedFile, bool>> predicate, Func<IQueryable<SharedFile>, IIncludableQueryable<SharedFile, object>>? include = null)
        {
            IQueryable<SharedFile> query = _context.SharedFiles;
            if (include != null)
                query = include(query);
            return query.SingleOrDefault(predicate);
        }

        public async Task<SharedFile?> GetAsync(Expression<Func<SharedFile, bool>> predicate, Func<IQueryable<SharedFile>, IIncludableQueryable<SharedFile, object>>? include = null)
        {
            IQueryable<SharedFile> query = _context.SharedFiles;
            if (include != null)
                query = include(query);
            return await query.SingleOrDefaultAsync(predicate);
        }

        public IPaginate<SharedFile> GetList(Expression<Func<SharedFile, bool>>? predicate = null, Func<IQueryable<SharedFile>, IIncludableQueryable<SharedFile, object>>? include = null,
            int index = 0, int size = 10, bool enableTracking = true)
        {
            IQueryable<SharedFile> query = _context.SharedFiles;
            if (!enableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return query.ToPaginate(index, size);
        }

        public async Task<IPaginate<SharedFile>> GetListAsync(Expression<Func<SharedFile, bool>>? predicate = null, Func<IQueryable<SharedFile>, IIncludableQueryable<SharedFile, object>>? include = null,
            int index = 0, int size = 10, bool enableTracking = true)
        {
            IQueryable<SharedFile> query = _context.SharedFiles;
            if (!enableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToPaginateAsync(index, size);
        }

        public void Update(SharedFile entity)
        {
            _context.SharedFiles.Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(SharedFile entity)
        {
            _context.SharedFiles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void SoftDelete(SharedFile entity)
        {
            entity.IsDeleted = true;
            _context.SharedFiles.Update(entity);
            _context.SaveChanges();
        }

        public async Task SoftDeleteAsync(SharedFile entity)
        {
            entity.IsDeleted = true;
            _context.SharedFiles.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
