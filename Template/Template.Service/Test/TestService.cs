using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Service.Test
{
    public class TestService : ITestService
    {
        public string GetString()
        {
            var str = string.Format("現在時間:{0}", DateTime.Now);
            return str;
        }
    }
}
