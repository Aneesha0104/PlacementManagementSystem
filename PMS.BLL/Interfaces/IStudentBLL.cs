using PMS.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public interface IStudentBLL
    {
        public StudentDto GetStudentByID(int Id);
        public void CreateStudent(StudentDto student);
        public StudentDto GetCollegeDepartmentDetails();
        List<StudentDto> GetAllStudentByCollegeId(int collegeId);
        public List<StudentDto> GetAllStudentsByPlacementDriveId(int placementDriveId);
        public int GetPlacementDriveCountByStudent(int studentID);
        public int GetAllocatedDriveCountByStudent(int studentID);
    }
}
