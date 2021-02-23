using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.ViewModels
{
    public class HeaderFooterVM
    {
        public Bio Bio { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Brand> MostSaledBrands { get; set; }
    }
}
