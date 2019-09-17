using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Template.Core.DependencyManagement
{
    public class IocManager
    {
        private readonly IUnityContainer _IContainer;

        public IocManager(IUnityContainer container)
        {
            this._IContainer = container;
        }

        public virtual IUnityContainer Container
        {
            get
            {
                return _IContainer;
            }
        }

        public virtual T Resolve<T>(string key = "") where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                return _IContainer.Resolve<T>();
            }
            return _IContainer.Resolve<T>(key);
        }
    }
}
