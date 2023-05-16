using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BOL
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Confirm  Password doesn't match, Try again !")]
        public string ConfirmPassowrd { get; set; }

        public byte Usertype { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte Status { get; set; }
        public StudentDto StudentDto { get; set; }
    }
}
