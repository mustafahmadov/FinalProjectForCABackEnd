using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.Models
{
    public class Bio
    {
        public int Id { get; set; }
        [Required]
        public string Logo { get; set; }
        [MaxLength(length:200)]
        public string Description { get; set; }
        public string WorkHours { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
    }
}
