using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.Models
{
    public class Guarantee
    {
        public int Id { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required,StringLength(maximumLength:25)]
        public string Title { get; set; }
    }
}
