using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Finder
{
    public interface ITypeFinder
    {
        /// <summary>
        /// 從類別中取回型別
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="onlyConcreteClasses"></param>
        /// <returns></returns>
        IEnumerable<Type> GetTypeByClasses<T>(bool onlyConcreteClasses = true);
    }
}
