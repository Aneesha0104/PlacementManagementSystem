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
        public int CollegeCount { get; set; }
        public int CompanyCount { get; set; }
        public int AllocatedStudentsCount { get; set; }
        public int PlacementDriveCount { get; set; }
        public int PlacementDriveCountByCollege { get; set; }
        public int PlacementDriveCountByStudent { get; set; }
        public int AllPlacedStudentsCount { get; set; }
        public int AllallocatedStudentsCount { get; set; }
        public int StudentCountByCollegeId { get; set; }
        public int AllocatedDriveCountByStudent { get;set; }
        
    }
}
