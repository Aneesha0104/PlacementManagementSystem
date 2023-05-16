using System;

namespace PMS.BOL
{
    public class CollegeDto
    {
        public int CollegeId { get; set; }

        public string CollegeName { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte Status { get; set; }

       public UserDto UserDto { get; set; }

    }
}