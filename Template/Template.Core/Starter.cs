using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Template.Core.DependencyManagement;
using Template.Core.Finder;
using Template.Core.Mapping;
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
            //自動註冊依賴項
            var typeFinder = new TypeFinder();
            AutoRegisterDependenices(typeFinder);
            //初始化MAPPER
            AutoMapperConfiguration(typeFinder);
            //註冊 API
            UnityWebApiActivator.Start();
            //註冊 MVC
            UnityMvcActivator.Start();


        }
        /// <summary>
        ///  自動註冊依賴項
        /// </summary>
        /// <param name="typeFinder"></param>
        private void AutoRegisterDependenices(TypeFinder typeFinder)
        {
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
        }
        /// <summary>
        /// 初始化MAPPER
        /// </summary>
        /// <param name="typeFinder"></param>
        private void AutoMapperConfiguration(TypeFinder typeFinder)
        {
            var mapperConfigs = typeFinder.GetTypeByClasses<IMappingOrder>();
            var mcInstance = mapperConfigs
                .Select(o => (IMappingOrder)Activator.CreateInstance(o))
                .OrderBy(o => o.Order);
            var config = new MapperConfiguration(o =>
            {
                foreach (var item in mcInstance)
                {
                    o.AddProfile(item.GetType());
                }
            });

            MapperConfig.Init(config);
            _iocManager.Container.RegisterInstance(MapperConfig.Mapper);
        }

    }
}
