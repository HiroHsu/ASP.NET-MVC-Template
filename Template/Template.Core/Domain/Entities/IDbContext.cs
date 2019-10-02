using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Template.Core.Domain.Entities
{
    /// <summary>
    /// 引用此介面的資料庫實體都可以在套用倉儲模式的時候自動判斷實體屬於哪個資料庫實體
    /// </summary>
    public interface IDbContext : IDisposable
    {
        /// <summary>
        /// 建立可用於查詢與儲存的實體實例
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
