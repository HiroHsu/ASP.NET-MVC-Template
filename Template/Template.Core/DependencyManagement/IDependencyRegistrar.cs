using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Template.Core.DependencyManagement
{
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 依賴注入註冊
        /// </summary>
        /// <param name="unitContainer"></param>
        void Register(IUnityContainer unitContainer);
        /// <summary>
        /// 註冊的順序
        /// </summary>
        int Order { get; }
    }
}
