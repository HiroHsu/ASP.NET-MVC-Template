using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Mapping
{
    public interface IMappingOrder
    {
        /// <summary>
        /// 決定載入映射Profile的順序,數值越大越後面
        /// </summary>
        int Order { get; }
    }
}
