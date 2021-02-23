using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        public List<Product> Products { get; set; }
        public bool HasDeleted { get; set; }
        public DateTime? DeletedTime { get; set; } 
        public int SaleCount { get; set; }
    }
}
