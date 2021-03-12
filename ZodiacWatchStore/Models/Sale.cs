using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerSurname { get; set; }
        [Required]
        public string CustomerFatherName { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public double Total { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
        public double ShippingPrice { get; set; }
        [Required]
        public string ShippingAddress { get; set; }
        [Required]
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public string Information { get; set; }
    }
}
