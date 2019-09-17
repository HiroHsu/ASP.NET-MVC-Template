using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.DependencyManagement;
using Unity;

namespace Template.Core
{
    public class Starter : IStarter
    {
        private IocManager _iocManager;
        public IocManager IocManager { get => _iocManager; set => _iocManager = value; }
        public void Initialize()
        {
            _iocManager = new IocManager(new UnityContainer());
            _iocManager.Container.RegisterInstance<IStarter>(this);


        }


    }
}
