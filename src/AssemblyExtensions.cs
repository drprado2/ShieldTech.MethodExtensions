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
    }
}