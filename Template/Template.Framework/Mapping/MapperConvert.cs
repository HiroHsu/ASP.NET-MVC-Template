using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Mapping;

namespace Template.Framework.Mapping
{
    public static class MapperConvert
    {
        /// <summary>
        /// 直接映射資料到目標
        /// </summary>
        /// <typeparam name="T">目標型別</typeparam>
        /// <param name="obj">來源模型</param>
        /// <returns></returns>
        public static T Map<T>(object obj) where T : class
        {
            return MapperConfig.Mapper.Map<T>(obj);
        }
        /// <summary>
        /// 直接映射資料到目標，如果來源與目標沒有事先建立好對應關係的話，系統自動判斷對應關係後，臨時建立一個關係，對應後消除。
        /// </summary>
        /// <typeparam name="TSource">來源型別</typeparam>
        /// <typeparam name="TDestination">目標型別</typeparam>
        /// <param name="source">來源模型</param>
        /// <param name="destination">目標模型</param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return MapTo<TDestination>(source, destination);
        }
        /// <summary>
        /// 直接映射資料到目標，如果來源與目標沒有事先建立好對應關係的話，系統自動判斷對應關係後，臨時建立一個關係，對應後消除。
        /// </summary>
        /// <typeparam name="TSource">來源型別</typeparam>
        /// <typeparam name="TDestination">目標型別</typeparam>
        /// <param name="source">來源模型</param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source) where TDestination : new()
        {
            return MapTo(source, new TDestination());
        }
        /// <summary>
        /// 自動判斷對應關係是否建立，若無則臨時新建一個對應關係。
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private static TDestination MapTo<TDestination>(object source, TDestination destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }
            var sourceType = GetObjectType(source.GetType());
            var destinationType = GetObjectType(typeof(TDestination));
            try
            {
                var map = MapperConfig.MapperConfiguration.FindTypeMapFor(sourceType, destinationType);
                if (map != null)
                {
                    return MapperConfig.Mapper.Map(source, destination);
                }
                var maps = MapperConfig.MapperConfiguration.GetAllTypeMaps();
                new MapperConfiguration(config =>
                {
                    foreach (var item in maps)
                    {
                        config.CreateMap(item.SourceType, item.DestinationType);
                    }
                    config.CreateMap(sourceType, destinationType);
                });
            }
            catch (InvalidOperationException)
            {
                new MapperConfiguration(config =>
                {
                    config.CreateMap(sourceType, destinationType);
                });
            }
            return MapperConfig.Mapper.Map(source, destination);
        }
        private static Type GetObjectType(Type source)
        {
            if (source.IsGenericType && typeof(IEnumerable).IsAssignableFrom(source))
            {
                var type = source.GetGenericArguments()[0];
                return GetObjectType(type);
            }
            return source;
        }
    }
}
