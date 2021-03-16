using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.ViewModels
{
    public class SaleForStatusVM
    {
        public List<Sale> RejectedSales { get; set; }
        public List<Sale> WaitingSales { get; set; }
        public List<Sale> SendingSales { get; set; }
        public List<Sale> FinishedSales { get; set; }
    }
}
