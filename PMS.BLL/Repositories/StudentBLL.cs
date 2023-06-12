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
        IPlacementAllocationRepository _placementAllocationRepository;
        public StudentBLL(IStudentRepository studentRepository, ICollegeRepository collegeRepository,IPlacementAllocationRepository placementAllocationRepository)
        {
            _studentRepository = studentRepository;
            _collegeRepository = collegeRepository;
            _placementAllocationRepository = placementAllocationRepository;
        }
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
        
       

        public List<StudentDto> GetAllStudentByCollegeId(int collegeId)
        {
            var students = _studentRepository.GetAll(x => x.Department.CollegeId == collegeId, x => x.Department);
            var studentDtoList = new List<StudentDto>();

            if (students != null)
            {
                foreach (var student in students)
                {
                    var studentDto = new StudentDto();
                    CopyToDto(student, studentDto);

                    // Check if the student is already allocated to any placement drive
                    var isStudentAllocated = _placementAllocationRepository.Any(x => x.StudentId == studentDto.StudentId);

                    // Update the AllocateToDrive property of the studentDto
                    studentDto.AllocateToDrive = isStudentAllocated;

                    studentDtoList.Add(studentDto);
                }
            } 

            return studentDtoList;
        }

        
     

        public List<StudentDto>GetAllStudentsByPlacementDriveId(int placementDriveId)
        {
            var students = _studentRepository.GetAll(x => x.PlacementAllocations.Any(p=>p.PlacementDriveId==placementDriveId && p.PlacementStatus==(byte)PMSEnums.PlacementStatus.ALLOCATED));
            var studentDtoList = new List<StudentDto>();
            if (students != null)
            {
                foreach (var student in students)
                {
                    var studentDto = new StudentDto();
                    CopyToDto(student, studentDto);

                    studentDtoList.Add(studentDto);
                }
            }

            return studentDtoList;

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
            target.DepartmentId = source.DepartmentId;

        }
        void CopyToDto(Student source, StudentDto target)
        {
            target.StudentId = source.StudentId;
            target.RegisterNo = source?.RegisterNo;
            target.Name = source.Name;
            target.Gender = source?.Gender;
            target.Dob = source.Dob;
            target.MobileNo = source.MobileNo;
            target.EmailId = source.EmailId;
            target.Address = source.Address;
            target.District = source.District;
            target.State = source.State;
            target.Pin = source.Pin;
            target.NameOfGuardian = source.NameOfGuardian;
            target.Occupation = source.Occupation;
            target.MaritalStatus = source.MaritalStatus;
            target.Mothertongue = source.Mothertongue;
            target.UserId = source.UserId;
            target.DepartmentId = source.DepartmentId;
            target.AcademicDetailId = source.AcademicDetailId;
            target.AcademicYear = source.AcademicYear;
            target.Remarks = source.Remarks;
            target.Hobbies = source.Hobbies;
            target.Skills = source.Skills;
            
        }
    }
    #endregion
}
