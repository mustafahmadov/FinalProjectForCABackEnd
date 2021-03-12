using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.CustomAttributes
{
    public class BooleanRequiredAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (bool)value;
        }
    }
}
