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

            UnityConfig.Container.RegisterInstance<IStarter>(this);
            //找出所有繼承 IDependencyRegistrar 的類別
            var drTypes = typeFinder.GetTypeByClasses<IDependencyRegistrar>();
            var drInstance = new List<IDependencyRegistrar>();

            foreach (var drType in drTypes)
            {
                //逐一建立實體
                drInstance.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            }
            drInstance = drInstance.OrderBy(o => o.Order).ToList();
            foreach (var drItem in drInstance)
            {
                //依照實體執行 Register 作業
                drItem.Register(UnityConfig.Container);
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

            //註冊AutoMapper
            UnityConfig.Container.RegisterInstance(MapperConfig.Mapper);
        }

    }
}
