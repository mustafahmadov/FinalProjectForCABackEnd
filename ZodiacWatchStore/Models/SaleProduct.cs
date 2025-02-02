﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.Models
{
    public class SaleProduct
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
