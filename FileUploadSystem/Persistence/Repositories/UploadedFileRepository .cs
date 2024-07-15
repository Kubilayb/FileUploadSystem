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
using FileUploadSystem.Persistence.Contexts;
using Application.Repositories;

namespace FileUploadSystem.Persistence.Repositories
{
    public class UploadedFileRepository : IUploadedFileRepository
    {
        private readonly FileUploadDbContext _context;

        public UploadedFileRepository(FileUploadDbContext context)
        {
            _context = context;
        }

        public void Add(UploadedFile entity)
        {
            _context.UploadedFiles.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(UploadedFile entity)
        {
            await _context.UploadedFiles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(UploadedFile entity)
        {
            _context.UploadedFiles.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(UploadedFile entity)
        {
            _context.UploadedFiles.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public UploadedFile? Get(Expression<Func<UploadedFile, bool>> predicate, Func<IQueryable<UploadedFile>, IIncludableQueryable<UploadedFile, object>>? include = null)
        {
            IQueryable<UploadedFile> query = _context.UploadedFiles;
            if (include != null)
                query = include(query);
            return query.SingleOrDefault(predicate);
        }

        public async Task<UploadedFile?> GetAsync(Expression<Func<UploadedFile, bool>> predicate, Func<IQueryable<UploadedFile>, IIncludableQueryable<UploadedFile, object>>? include = null)
        {
            IQueryable<UploadedFile> query = _context.UploadedFiles;
            if (include != null)
                query = include(query);
            return await query.SingleOrDefaultAsync(predicate);
        }

        public IPaginate<UploadedFile> GetList(Expression<Func<UploadedFile, bool>>? predicate = null, Func<IQueryable<UploadedFile>, IIncludableQueryable<UploadedFile, object>>? include = null,
            int index = 0, int size = 10, bool enableTracking = true)
        {
            IQueryable<UploadedFile> query = _context.UploadedFiles;
            if (!enableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return query.ToPaginate(index, size);
        }

        public async Task<IPaginate<UploadedFile>> GetListAsync(Expression<Func<UploadedFile, bool>>? predicate = null, Func<IQueryable<UploadedFile>, IIncludableQueryable<UploadedFile, object>>? include = null,
            int index = 0, int size = 10, bool enableTracking = true)
        {
            IQueryable<UploadedFile> query = _context.UploadedFiles;
            if (!enableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToPaginateAsync(index, size);
        }

        public void Update(UploadedFile entity)
        {
            _context.UploadedFiles.Update(entity);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(UploadedFile entity)
        {
            _context.UploadedFiles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void SoftDelete(UploadedFile entity)
        {
            entity.IsDeleted = true;
            _context.UploadedFiles.Update(entity);
            _context.SaveChanges();
        }

        public async Task SoftDeleteAsync(UploadedFile entity)
        {
            entity.IsDeleted = true;
            _context.UploadedFiles.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
