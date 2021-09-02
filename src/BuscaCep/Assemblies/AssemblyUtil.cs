using System.Collections.Generic;
using System.Reflection;

namespace BuscaCep.Assemblies
{
    public static class AssemblyUtil
    {
        public static IEnumerable<Assembly> Assemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("BuscaCep"),
                Assembly.Load("Infraestrutura")
            };
        }
    }
}
