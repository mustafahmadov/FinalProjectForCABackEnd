using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.ViewModels
{
    public class ProductPartialVM
    {
        public IQueryable<Product> products;
        public Decimal? PageCount { get; set; }
        public int? Page { get; set; }
    }
}
