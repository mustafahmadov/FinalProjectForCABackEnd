using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.Extention;

namespace ZodiacWatchStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Column("Type")]
        public string Name
        {
            get { return Type.ToString(); }
            private set { Type = value.ParseEnum<CategoryType>(); }
        }

        [NotMapped]
        public CategoryType Type { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
