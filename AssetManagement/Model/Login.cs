using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Model
{
    public class Login
    {
        public Login()
        {
                
        }

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public int Contactnumber { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
