using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Template.Core
{
    /// <summary>
    /// 執行啟動器
    /// </summary>
    public class StarterRun
    {
        /// <summary>
        /// 執行器初始化
        /// </summary>
        public static void Initialize()
        {
            var starter = new Starter();
            starter.Initialize();

        }
    }
}
