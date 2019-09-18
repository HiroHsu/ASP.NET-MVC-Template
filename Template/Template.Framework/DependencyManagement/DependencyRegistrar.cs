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
        public int Order => 3;

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
