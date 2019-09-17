using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Finder
{
    public class TypeFinder : ITypeFinder
    {
        public IEnumerable<Type> GetTypeByClasses<T>(bool onlyConcreteClasses = true)
        {

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assignType = typeof(T);
            var result = new List<Type>();

            foreach (var assemblie in assemblies)
            {
                var types = assemblie.GetTypes();
                if (types == null)
                {
                    continue;
                }

                var list = types.Where(o =>
                    (assignType.IsAssignableFrom(o) || (assignType.IsGenericParameter && TypeImplementOpenGenerics(o, assignType)))
                    && !o.IsInterface
                );
                if (onlyConcreteClasses)
                {
                    list = list.Where(o => o.IsClass && !o.IsAbstract);
                }
                result.AddRange(list);

            }
            return result;
        }

        private bool TypeImplementOpenGenerics(Type type, Type assignType)
        {
            try
            {
                var genericTypeDefinition = assignType.GetGenericTypeDefinition();
                foreach (var item in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!item.IsGenericType)
                    {
                        continue;
                    }
                    return genericTypeDefinition.IsAssignableFrom(item.GetGenericTypeDefinition());
                }
                return false;
            }
            catch
            {

                return false;
            }



        }
    }
}
