﻿using Microsoft.EntityFrameworkCore;
using SMStore.Data;
using SMStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMStore.Service.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new() //T kısmı gönderilecek olan yapı için şartlar koyduk. T bir class olmak zorunda , IEntity interface inden gelmek zorunda ve new lenebilir bir tip olmak zorunda 
    {

        internal readonly DatabaseContext _databaseContext;

        public Repository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = _databaseContext.Set<T>();
        }

        DbSet<T> _dbSet; // databaseContext teki dbsetleri generic olarak kullanabilmemiz için 

        public void Add(T entity)  //eğer bu metodun dönüş tipini void yerine int yapsaydık 
        {
            _dbSet.Add(entity);
            // Burada geriye retur ile save changesi dönmemiz gerekirdi
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity); // parametreyle gelecek classı asenkron olarak ekle
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> FindAsync()
        {
            return await _dbSet.FindAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public int SaveChanges()
        {
            return _databaseContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _databaseContext.Update(entity);
        }

       
    }
}
