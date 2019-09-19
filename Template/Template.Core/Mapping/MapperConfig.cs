using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Mapping
{
    public static class MapperConfig
    {
        /// <summary>
        /// Mapper 物件
        /// </summary>
        public static IMapper Mapper { get; private set; }
        /// <summary>
        /// MapperConfiguration 物件
        /// </summary>
        public static MapperConfiguration MapperConfiguration { get; private set; }
        /// <summary>
        /// 初始化 Mapper 物件
        /// </summary>
        /// <param name="config"></param>
        public static void Init(MapperConfiguration config)
        {
            MapperConfiguration = config;
            Mapper = config.CreateMapper();
        }

    }
}
