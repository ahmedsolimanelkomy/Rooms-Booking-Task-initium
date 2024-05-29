using Microsoft.EntityFrameworkCore;
using Rooms_Booking.IRepository;
using Rooms_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rooms_Booking.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RoomsBookingContext _context;
        internal DbSet<T> _dbSet;

        public Repository(RoomsBookingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T GetById(Expression<Func<T, bool>> Filter, string? IncludeProps = null)
        {
            IQueryable<T>? Query = _dbSet;
            if (IncludeProps != null)
            {
                foreach (var includeProp in IncludeProps.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(includeProp);
                }
            }
            return Query.FirstOrDefault(Filter);
        }

        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = _dbSet;
            if (includeProps != null)
            {
                foreach (var includeProp in includeProps.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter, string? includeProps = null)
        {
            IQueryable<T> query = _dbSet;
            if (includeProps != null)
            {
                foreach (var includeProp in includeProps.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.Where(filter).ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
