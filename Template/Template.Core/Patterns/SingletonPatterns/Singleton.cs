using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Patterns.SingletonPatterns
{
    /// <summary>
    /// 單例模式
    /// </summary>
    public class Singleton
    {
        private static List<SingletonModel> _singletons;
        /// <summary>
        /// 展示所有的單例清單
        /// </summary>
        public static List<SingletonModel> Singletons
        {
            get => _singletons;
        }
        static Singleton()
        {
            _singletons = new List<SingletonModel>();
        }

        /// <summary>
        /// 使用關鍵名稱設定一個傳入的物件為單一實體，供未來取回時依然是同一個實體
        /// </summary>
        /// <typeparam name="T">型別</typeparam>
        /// <param name="keyName">關鍵名稱</param>
        /// <param name="obj">物件</param>
        public static void Set<T>(string keyName, dynamic obj)
        {
            var singleton = Get<T>(keyName);
            if (singleton == null)
            {
                var model = new SingletonModel();
                model.KeyName = keyName;
                model.ObjectType = typeof(T);
                model.Object = obj;
                _singletons.Add(model);
            }
        }

        /// <summary>
        /// 以關鍵名稱取回已個已經存在的實例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName"></param>
        /// <returns>若找不到關鍵名稱所在的實例，將傳回NULL</returns>
        public static T Get<T>(string keyName)
        {
            var model = _singletons.SingleOrDefault(o => o.KeyName.Equals(keyName));
            if (model != null)
            {
                return (T)model.Object;
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// 在某些特殊情況，需要重新設定實體，就可以使用這個方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyName"></param>
        /// <param name="obj"></param>
        public static void ReSet<T>(string keyName, dynamic obj)
        {
            var singleton = Get<T>(keyName);
            if (singleton != null)
            {
                var model = _singletons.SingleOrDefault(o => o.KeyName.Equals(keyName));
                model.KeyName = keyName;
                model.ObjectType = typeof(T);
                model.Object = obj;
            }
        }

    }
}
