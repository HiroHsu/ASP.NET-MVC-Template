using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Patterns.RepositoryPatterns
{
    public partial interface IRepository<T> where T : class
    {
        /// <summary>
        /// 寫入單筆紀錄
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);
        /// <summary>
        /// 寫入整批紀錄
        /// </summary>
        /// <param name="entities"></param>
        void Insert(IEnumerable<T> entities);
        /// <summary>
        /// 更新單筆紀錄
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 更新整批紀錄
        /// </summary>
        /// <param name="entities"></param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// 刪除單筆紀錄
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// 刪除整批紀錄
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// 查詢
        /// </summary>
        IQueryable<T> Query { get; }
        /// <summary>
        /// 查詢但不快取資料內文，直接從資料庫
        /// </summary>
        IQueryable<T> QueryAsNoTracking { get; }
        /// <summary>
        /// 查詢全部資料
        /// </summary>
        /// <returns>該表的所有資料 IQueryable </returns>
        IQueryable<T> QueryAll();
        /// <summary>
        /// 查詢符合條件的資料，就算出現很多筆，也只取第一筆
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T QueryFirst(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 儲存改變
        /// </summary>
        void Save();
    }
}
