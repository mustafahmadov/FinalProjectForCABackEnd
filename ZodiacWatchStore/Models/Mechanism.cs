using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.Models
{
    public class Mechanism
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public bool HasDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
