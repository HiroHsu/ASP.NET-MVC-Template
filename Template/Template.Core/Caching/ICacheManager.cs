using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Caching
{
   public interface ICacheManager
    {
        /// <summary>
        /// 取回一個快取物件，如果快取裡面找不這個物件的快取，則儲存它到快取之中
        /// </summary>
        /// <typeparam name="T">這個快取的型態，請注意型態必須正確，否則將於執行階段出錯</typeparam>
        /// <param name="key">快取的關鍵名稱</param>
        /// <param name="acquire">如果快取沒有這個物件，將執行這個函式並儲存到快取之中</param>
        /// <param name="cacheTime">設定快取時間，以分鐘計，若為NULL則使用預設時間(60)</param>
        /// <returns></returns>
        T Get<T>(string key, Func<T> acquire, int? cacheTime = null);
        /// <summary>
        /// 增加一個關鍵字串與關聯內容到快取
        /// </summary>
        /// <param name="key">關鍵字串</param>
        /// <param name="data">關聯內容</param>
        /// <param name="cacheTime">快取的時間</param>
        void Set(string key, object data, int cacheTime);
        /// <summary>
        /// 檢查關鍵字串與其關聯內容是否已被快取
        /// </summary>
        /// <param name="key">關鍵字串</param>
        /// <returns>內容</returns>
        bool IsSet(string key);
        /// <summary>
        /// 從快取池中移除一個關鍵字串與其關聯內容
        /// </summary>
        /// <param name="key">關鍵字串</param>
        void Remove(string key);
        /// <summary>
        /// 從Pattern 移除一個項目
        /// </summary>
        /// <param name="key"></param>
        void RemoveByPattern(string key);
        /// <summary>
        /// 清除所有快取
        /// </summary>
        void Clear();
    }
}
