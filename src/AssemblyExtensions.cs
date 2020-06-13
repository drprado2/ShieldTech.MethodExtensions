using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ShieldTech.MethodExtensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetTypesFromAssemblyAndReferenced(this Assembly assembly)
        {
            return assembly
                .GetReferencedAssemblies()
                .Select(x => Assembly.Load(x))
                .Concat(new[] {assembly})
                .SelectMany(x => x.GetTypes());
        }

        public static IEnumerable<Type> SafeGetTypesFromDomainAssemblies()
        {
            IEnumerable<Type> types;
            try
            {
                types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(x => x != null);
            }

            return types;
        }
    }
}