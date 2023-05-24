using PMS.BOL;
using PMS.DAL;
using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PMS.BLL
{
    public class DepartmentBLL : IDepartmentBLL
    {
        IDepartmentRepository _departmentRepository;

        public DepartmentBLL(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public List<DepartmentDto> GetAllDepartmentBll()
        {
            var department = _departmentRepository.GetAll(x => x.Status == (byte)PMSEnums.RecordStatus.ACTIVE);
            var departmentDtoList = new List<DepartmentDto>();
            if (department != null)
            {
                foreach (var item in department)
                {
                    var departmentDto = new DepartmentDto();
                    CopyToDto(item, departmentDto);
                    departmentDtoList.Add(departmentDto);
                }
            }
            return departmentDtoList;
        }
        public DepartmentDto GetDepartmentByDepartmentId(int departmentId)
        {
            var department = _departmentRepository.FirstOrDefault(x => x.DepartmentId == departmentId);
            var departmenttDto = new DepartmentDto();
            if (department != null)
            {
                CopyToDto(department, departmenttDto);
            }
            return departmenttDto;

        }
        public List<DepartmentDto> GetDepartmentunderCollege(int CollegeID)
        {
            var department = _departmentRepository.GetAll(x => x.CollegeId == CollegeID);
            var departmentDtoList = new List<DepartmentDto>();
            if (department!= null)
            {
                foreach (var dep in department)
                {
                    var departmentDto = new DepartmentDto();
                    CopyToDto(dep, departmentDto);
                    departmentDtoList.Add(departmentDto);
                }                            
            }
            return departmentDtoList;
        }
        public bool UpdateDepartment(DepartmentDto departmentDto)
        {
            try
            {
                var department = _departmentRepository.FirstOrDefault(x => x.DepartmentId == departmentDto.DepartmentId);
                CopyFromDto(departmentDto, department);
                _departmentRepository.Update(department);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateDepartment(DepartmentDto departmentDto)
        {
            try
            {
                var department = new Department();
                CopyFromDto(departmentDto, department);
                _departmentRepository.Insert(department);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        void CopyFromDto(DepartmentDto source, Department target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.CreatedOn = DateTime.Now;
            target.Status = (byte)PMSEnums.RecordStatus.ACTIVE;
            target.CollegeId = source.CollegeId;
            
        }

        void CopyToDto(Department source, DepartmentDto target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.CreatedOn = source.CreatedOn;
            target.Status = source.Status;
            target.CollegeId = source.CollegeId;
            target.DepartmentId = source.DepartmentId;



        }

    }
}
