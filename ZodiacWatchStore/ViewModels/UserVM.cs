using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZodiacWatchStore.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }
        //public List<IdentityRole> Roles { get; set; }
        public List<string> Roles { get; set; }
    }
}
