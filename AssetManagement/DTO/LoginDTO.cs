using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public int Contactnumber { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
