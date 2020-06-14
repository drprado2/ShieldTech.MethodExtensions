using System;

namespace ShieldTech.MethodExtensions
{
    public static class TypeExtensions
    {
        public static object GetDefaultInstance(Type type)
        {
            if(type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}