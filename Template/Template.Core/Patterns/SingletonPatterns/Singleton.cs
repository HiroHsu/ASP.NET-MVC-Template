using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Patterns.SingletonPatterns
{
    public class Singleton
    {
        private static List<SingletonModel> _singletons;

        public static List<SingletonModel> Singletons
        {
            get => _singletons;
        }
        static Singleton()
        {
            _singletons = new List<SingletonModel>();
        }


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


    }
}
