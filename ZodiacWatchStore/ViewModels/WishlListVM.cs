using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.ViewModels
{
    public class WishlListVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Model { get; set; }
        public string ProductCode { get; set; }
        public int StatusCount { get; set; }
        public double Price { get; set; }
        public string UserName { get; set; }
    }
}
