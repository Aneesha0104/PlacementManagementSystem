using System;

namespace PMS.BOL
{
    public class StudentDto
    {
        public int StudentId { get; set; }

        public string RegisterNo { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime Dob { get; set; }

        public string MobileNo { get; set; }

        public string EmailId { get; set; }

        public string Address { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        public decimal Pin { get; set; }

        public string NameOfGuardian { get; set; }

        public string Occupation { get; set; }

        public string MaritalStatus { get; set; }

        public string Mothertongue { get; set; }

        public int? UserId { get; set; }

        public int DepartmentId { get; set; }

        public int AcademicDetailId { get; set; }

        public string AcademicYear { get; set; }

        public string Remarks { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Hobbies { get; set; }

        public string Skills { get; set; }

        public byte Status { get; set; }

        public virtual AcademicDetailDto AcademicDetailDto { get; set; }

        public virtual DepartmentDto DepartmentDto { get; set; }

        public virtual UserDto UserDto { get; set; }
    }
}