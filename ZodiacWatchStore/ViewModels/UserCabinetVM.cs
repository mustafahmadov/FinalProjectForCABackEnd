using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ZodiacWatchStore.Models;

namespace ZodiacWatchStore.ViewModels
{
    public class UserCabinetVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string CheckPassword { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string DetalizedAddress { get; set; }
        public string Information { get; set; }
        public string PassportID { get; set; }
        public string FIN { get; set; }
        public AppUser User { get; set; }
        public List<WishlListVM> UserWishlist { get; set; }

        public List<Sale> UserSales { get; set; }


    }
}
