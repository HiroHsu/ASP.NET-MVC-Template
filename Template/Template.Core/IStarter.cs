using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core
{
    public interface IStarter
    {
        DependencyManagement.IocManager IocManager { get; set; }

        void Initialize();
    }
}
