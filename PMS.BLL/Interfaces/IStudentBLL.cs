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
    }
}
