using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core
{
    /// <summary>
    /// 啟動器介面
    /// </summary>
    public interface IStarter
    {
        /// <summary>
        /// 專案初始化作業
        /// </summary>

        void Initialize();
    }
}
