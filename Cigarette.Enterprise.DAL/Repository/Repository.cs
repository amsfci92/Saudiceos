using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SaudiceosEntities _context;
        public Repository(SaudiceosEntities context)
        {
            _context = context;
        }
        public void StopLazyLoad()
        {
            _context.Configuration.LazyLoadingEnabled = false;
        }
        public virtual TEntity Get(long id)
        {
            var res =  _context.Set<TEntity>().Find(id);
           //_context.Entry(res).State = EntityState.Detached;
            return res;
        }
        public virtual TEntity Get(int id)
        {
            var res = _context.Set<TEntity>().Find(id);
            _context.Entry(res).State = EntityState.Detached;
            return res;
        }

        public TEntity Get(string id)
        {
            var res = _context.Set<TEntity>().Find(id);
            _context.Entry(res).State = EntityState.Detached;
            return res;
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entiy)
        {
            try
            {
                entiy = _context.Set<TEntity>().Add(entiy);

                _context.SaveChanges();

                return entiy;
            }


            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public virtual int AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            var result = _context.SaveChanges();

            return result;
        }

        public int Update(TEntity entiy)
        {
            try
            { 
                _context.Set<TEntity>().AddOrUpdate(entiy);
                //_context.Entry(entiy).CuState = EntityState.Modified;
                var result = _context.SaveChanges();

                return result;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }


        public virtual int Remove(TEntity entiy)
        {
            _context.Set<TEntity>().Remove(entiy);
            var result = _context.SaveChanges();

            return result;
        }

        public virtual int RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach(var i in entities)
            { 
                _context.Set<TEntity>().Attach(i);
            }
            _context.Set<TEntity>().RemoveRange(entities);
            var result = _context.SaveChanges();

            return result;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
