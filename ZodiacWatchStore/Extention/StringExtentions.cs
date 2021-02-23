using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.Extention
{
    public static class StringExtentions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
