using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Mapping;

namespace Template.Framework.Mapping
{
    public partial class MapperProfile : Profile, IMappingOrder
    {
        public int Order => 1;
        public MapperProfile()
        {
            //在這裡輸入要映射的資料模型
            //CreateMap<Schema, SchemaViewModel>()
            //    .ForMember(t => t.DBRule, s => s.MapFrom(x => x.DBRule))
            //    .ForMember(t => t.CONST, s => s.MapFrom(x => x.Const))
            //    .ForMember(t => t.DBTable, s => s.Ignore())
            //    .ForMember(t => t.ITEM, s => s.MapFrom(x => x.Index))
            //    .ForMember(t => t.ParmORD, s => s.MapFrom(x => x.Order))
            //    .ForMember(t => t.PARM, s => s.MapFrom(x => x.ParameterName))
            //    ;
        }
    }
}
