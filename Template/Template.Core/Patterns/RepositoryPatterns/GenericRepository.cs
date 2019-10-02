using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Domain.Entities;
using Template.Core.Finder;
using Template.Core.Patterns.SingletonPatterns;

namespace Template.Core.Patterns.RepositoryPatterns
{
    public abstract partial class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private readonly ITypeFinder _typeFinder;
        private IDbSet<T> _entities;

        public GenericRepository(IDbContext context, ITypeFinder typeFinder)
        {
            this._typeFinder = typeFinder;

            var tEntityNamespace = typeof(T).Namespace;
            //從中取回所有資料庫，並判斷其中 Namespace 是否符合實體的主要 Namespace

            var dbContextList = typeFinder.GetTypeByClasses<IDbContext>();
            foreach (var dbContext in dbContextList)
            {
                //在這裡使用了單例模式，避免出現儲存時上下文不同的情況
                if (Singleton.Get<IDbContext>(tEntityNamespace) == null)
                {
                    Singleton.Set<IDbContext>(tEntityNamespace, (IDbContext)Activator.CreateInstance(dbContext));
                }
                _context = Singleton.Get<IDbContext>(tEntityNamespace);
            }
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }


        public IQueryable<T> Query
        {
            get
            {
                try
                {
                    return this.Entities;
                }
                catch (DbEntityValidationException dbEx)
                {

                    throw new Exception(GetFullErrorText(dbEx), dbEx);
                }
            }

        }

        public IQueryable<T> QueryAsNoTracking
        {
            get
            {
                try
                {
                    return this.Entities.AsNoTracking();
                }
                catch (DbEntityValidationException dbEx)
                {

                    throw new Exception(GetFullErrorText(dbEx), dbEx);
                }
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    this.Entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        public void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }

                foreach (var entity in entities)
                {
                    this.Entities.Add(entity);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        public IQueryable<T> QueryAll()
        {
            return _entities.AsQueryable();
        }

        public T QueryFirst(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<T> entities)
        {

            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }
                foreach (var item in entities)
                {
                    Update(item);
                }

            }
            catch (DbEntityValidationException dbEx)
            {
                throw new Exception(GetFullErrorText(dbEx), dbEx);
            }
        }

        #region Utilities

        /// <summary>
        /// 取得所有錯誤
        /// </summary>
        /// <param name="exc"></param>
        /// <returns></returns>
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += string.Format("Property: {0} 錯誤: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
            return msg;
        }


        #endregion
    }
}
