using System;

namespace PMS.BOL
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }

        public int CollegeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte Status { get; set; }

        public virtual CollegeDto CollegeDto { get; set; }
    }
}