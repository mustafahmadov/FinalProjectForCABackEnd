using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.ViewModels
{
    public class CheckOutVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required] 
        public string City { get; set; }
        public string District { get; set; }
        [Required]
        public string DetalizedAddress { get; set; }
        [Required(ErrorMessage = "Telefon nömrəsini daxil edin")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^((\(?\+994\)?)|(0))?\d{2}\d{3}\d{2}\d{2}$", ErrorMessage = "Düzgün nömrə deyil!")]
        public string PhoneNumber { get; set; }
        [StringLength(maximumLength:250)]
        public string Information { get; set; }

    }
}
