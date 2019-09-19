using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.DependencyManagement;
using Unity;
using Unity.RegistrationByConvention;

namespace Template.Framework.DependencyManagement
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// 註冊依賴項目的順序，越大越晚
        /// </summary>
        public int Order => 3;
        /// <summary>
        /// 註冊依賴項目
        /// </summary>
        /// <param name="unitContainer"></param>
        public void Register(IUnityContainer unitContainer)
        {
            //自動註冊
            unitContainer.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default
                );

        }
    }
}
