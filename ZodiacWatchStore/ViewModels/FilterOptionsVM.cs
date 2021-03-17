using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.ViewModels
{
    public class FilterOptionsVM
    {
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? MechanismId { get; set; }
        public int? CaseThicksId { get; set; }
        public int? BandTypeId { get; set; }
        public int? GlassTypeId { get; set; }
        public int? WaterProtectionId { get; set; }
    }
}
