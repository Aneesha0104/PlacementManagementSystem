using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BOL
{
    public class LoggedInUserVM
    {
        public StudentDto StudentDto { get; set; }    
        public CompanyDto CompanyDto { get; set; }
        public CollegeDto CollegeDto { get; set; }
        public byte UserType { get; set; }
        public string UserName{ get; set; }
        public int PlacedStudentCount { get; set; }
        public int StudentCount { get; set; }

        public int CompanyCount { get; set; }
        public int AllocatedStudentsCount { get; set; }
        
    }
}
