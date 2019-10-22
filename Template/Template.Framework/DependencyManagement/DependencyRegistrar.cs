using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.DependencyManagement;
using Template.Core.Domain.Entities;
using Template.Core.Finder;
using Unity;
using Unity.Injection;
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
        /// <param name="unityContainer"></param>
        public void Register(IUnityContainer unityContainer, ITypeFinder typeFinder)
        {
            //註冊資料庫(自動註冊)
            foreach (var dbContext in typeFinder.GetTypeByClasses<IDbContext>())
            {
                unityContainer.RegisterFactory<IDbContext>(dbContext.Namespace, c => (IDbContext)Activator.CreateInstance(dbContext));
            }

            //自動註冊
            unityContainer.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default
                );

        }
    }
}
