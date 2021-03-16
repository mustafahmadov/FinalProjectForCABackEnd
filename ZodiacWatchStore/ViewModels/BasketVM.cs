using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.ViewModels
{
    public class BasketVM
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string WatchCode { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        
    }
}
