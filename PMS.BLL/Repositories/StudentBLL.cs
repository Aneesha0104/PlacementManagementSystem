using Microsoft.AspNetCore.Mvc.Rendering;
using PMS.BOL;
using PMS.DAL;
using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public class StudentBLL : IStudentBLL
    {
        IStudentRepository _studentRepository;
        ICollegeRepository _collegeRepository;
        public StudentBLL(IStudentRepository studentRepository, ICollegeRepository collegeRepository)
        {
            _studentRepository = studentRepository;
            _collegeRepository = collegeRepository;
        }
        //public StudentBLL(ICollegeRepository collegeRepository)
        //{
        //    _collegeRepository = collegeRepository;
        //}
        public StudentDto GetStudentByID(int Id)
        {
            StudentDto _studentDto = new StudentDto();
            var Student = _studentRepository.FirstOrDefault(x => x.UserId == Id);
            if (Student != null) CopyToDto(Student, _studentDto);
            return _studentDto;
        }
        public void CreateStudent(StudentDto student)
        {
            var _student = new Student();
            CopyFromDto(student, _student);
            _studentRepository.Insert(_student);
        }

        public StudentDto GetCollegeDepartmentDetails()
        {
            StudentDto _studentDto = new StudentDto();
            _studentDto.Collegelist = new List<SelectListItem>();
            _studentDto.Collegelist = new SelectList(_collegeRepository.GetAll(), "CollegeId", "CollegeName");
            _studentDto.Departmentlist =new List<SelectListItem>();
            return _studentDto;
        }

        #region copy
        void CopyFromDto(StudentDto source, Student target)
        {
            target.Name = source.Name;
            target.CreatedOn = DateTime.Now;
            target.Status = (byte)PMSEnums.RecordStatus.ACTIVE;
            if (source.UserDto != null)
            {
                target.User = new User();
               target.User.Username = source.UserDto.Username;
                target.User.Password = source.UserDto.Password;
                target.User.Usertype = (byte)PMSEnums.UserType.STUDENT;
                target.User.CreatedOn = DateTime.Now;
                target.User.Status = (byte)PMSEnums.RecordStatus.ACTIVE;

            }
            target.DepartmentId = 5;

        }
        void CopyToDto(Student source, StudentDto target)
        {
            target.StudentId = source.StudentId;
            target.RegisterNo = source?.RegisterNo;
            target.Name = source.Name;
            target.Gender = source?.Gender;
            target.Dob = (DateTime)source.Dob;
            target.MobileNo = source.MobileNo;
            target.EmailId = source.EmailId;
            target.Address = source.Address;
            target.District = source.District;
            target.State = source.State;
            target.Pin = (decimal)source.Pin;
            target.NameOfGuardian = source.NameOfGuardian;
            target.Occupation = source.Occupation;
            target.MaritalStatus = source.MaritalStatus;
            target.Mothertongue = source.Mothertongue;
            target.UserId = source.UserId;
            target.DepartmentId = source.DepartmentId;
            target.AcademicDetailId = (int)source.AcademicDetailId;
            target.AcademicYear = source.AcademicYear;
            target.Remarks = source.Remarks;
            target.Hobbies = source.Hobbies;
            target.Skills = source.Skills;
        }
    }
    #endregion
}
