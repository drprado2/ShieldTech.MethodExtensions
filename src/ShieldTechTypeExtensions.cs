using System;

namespace ShieldTech.MethodExtensions
{
    public static class ShieldTechTypeExtensions
    {
        public static object GetDefaultInstance(this Type type)
        {
            if(type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}