using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Sieve.Extensions
{
    public static partial class TypeExtensions
    {
        public static bool IsNullable(this Type type)
        {
            return !type.IsValueType || Nullable.GetUnderlyingType(type) != null;
        }
    }
}
