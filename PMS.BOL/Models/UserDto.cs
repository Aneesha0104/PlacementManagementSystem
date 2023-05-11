using System;
using System.Collections.Generic;
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

        public byte Usertype { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte Status { get; set; }
    }
}
