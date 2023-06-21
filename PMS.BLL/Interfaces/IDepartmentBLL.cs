using PMS.BOL;
using System.Collections.Generic;

namespace PMS.BLL
{
    public interface IDepartmentBLL
    { 
        List<DepartmentDto> GetAllDepartmentBll();

        DepartmentDto GetDepartmentByDepartmentId(int DepartmentID);
        public bool DeleteDeparment(int departmentId);
        bool UpdateDepartment(DepartmentDto departmentDto);
        bool CreateDepartment(DepartmentDto departmentDto);
        public List<DepartmentDto> GetDepartmentunderCollege(int CollegeID);

    }
}