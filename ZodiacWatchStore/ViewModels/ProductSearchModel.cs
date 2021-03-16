using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.ViewModels
{
    public class ProductSearchModel
    {
            public int? Id { get; set; }
            public int? PriceFrom { get; set; }
            public int? PriceTo { get; set; }
    }
}
