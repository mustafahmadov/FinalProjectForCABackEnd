using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public bool HasDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool Status { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingDistrict { get; set; }
        public string DetalizedShippingAddress { get; set; }
        public string Information { get; set; }
        public string PassportID { get;set;}
        public string FIN { get; set; }
    }
}
