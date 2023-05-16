using System;

namespace PMS.BOL
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Branches { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }

        public string ContactNo { get; set; }

        public string EmailId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Remarks { get; set; }

        public byte Status { get; set; }
        public UserDto UserDto { get; set; }

    }
}