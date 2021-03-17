using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZodiacWatchStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string WatchCode { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int SaleCount { get; set; }
        [Required]
        public double Price { get; set; }
        public int Discount { get; set; }
        public bool HasDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public int ViewCount { get; set; }
        public Mechanism Mechanism { get; set; }
        public int MechanismId { get; set; }
        public BandType BandType { get; set; }
        public int BandTypeId { get; set; }
        public WaterProtection WaterProtection { get; set; }
        public int WaterProtectionId { get; set; }
        public CaseThick CaseThick { get; set; }
        public int CaseThickId { get; set; }
        public GlassType GlassType { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public int GlassTypeId { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        [NotMapped]
        public IFormFile MainPhoto { get; set; }
        [NotMapped]
        public IFormFile[] Photos { get; set; }





    }
}
