using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.CustomAttributes;

namespace ZodiacWatchStore.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Istifadəçi adı bölməsi boş qala bilməz"), StringLength(100)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email ünvanı bölməsi boş qala bilməz"), EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifrə bölməsi boş qala bilməz"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifrəni təkrar daxil edin"), DataType(DataType.Password), Compare(nameof(Password))]
        public string CheckPassword { get; set; }

        //[Required(ErrorMessage = "Telefon nömrəsini daxil edin")]
        //[Display(Name = "Home Phone")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^((\(?\+994\)?)|(0))?\d{2}\d{3}\d{2}\d{2}$", ErrorMessage = "Düzgün nömrə deyil!")]
        //public string PhoneNumber { get; set; }
        [Required]
        [Display(Name="Accept terms and conditions")]
        public bool PrivacyAggrement { get; set; }


    }
}
