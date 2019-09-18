using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Template.Core.DependencyManagement;
using Template.Core.Finder;
using Unity;
using Unity.AspNet.WebApi;

namespace Template.Core
{
    public class Starter : IStarter
    {
        private IocManager _iocManager;
        public IocManager IocManager { get => _iocManager; set => _iocManager = value; }
        public void Initialize()
        {
            var typeFinder = new TypeFinder();
            _iocManager = new IocManager(UnityConfig.Container);
            _iocManager.Container.RegisterInstance<IStarter>(this);

            var drTypes = typeFinder.GetTypeByClasses<IDependencyRegistrar>();
            var drInstance = new List<IDependencyRegistrar>();

            foreach (var drType in drTypes)
            {
                drInstance.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            }
            drInstance = drInstance.OrderBy(o => o.Order).ToList();
            foreach (var drItem in drInstance)
            {
                drItem.Register(_iocManager.Container);
            }
            

            UnityWebApiActivator.Start();
            UnityMvcActivator.Start();

        }


    }
}
