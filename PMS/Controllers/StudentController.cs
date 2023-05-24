using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMS.BLL;
using PMS.BOL;

namespace PMS.Controllers
{
    public class StudentController : Controller
    {
        IStudentBLL _studentBLL;
        IDepartmentBLL _departmentBLL;
        IUserBLL _userBLL;
        public StudentController(IStudentBLL studentBLL, IDepartmentBLL departmentBLL, IUserBLL userBLL)
        {
            _studentBLL = studentBLL;
            _departmentBLL = departmentBLL;
            _userBLL = userBLL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            var studentDto = _studentBLL.GetCollegeDepartmentDetails();
            return View(studentDto);
        }
        public ActionResult GetDepartments(int id)
        {
            if(id > 0)
            {

                StudentDto _studentDto = new StudentDto();
                _studentDto.Departmentlist = new List<SelectListItem>();
                _studentDto.Departmentlist = new SelectList(_departmentBLL.GetDepartmentunderCollege(id), "DepartmentId", "Name");
                return Json(_studentDto.Departmentlist);
            } 
            return null;
        }
        [HttpPost]
        public IActionResult Register(StudentDto studentDto)
        {
            if (ModelState.IsValid && studentDto != null)
            {
                if (_userBLL.CheckUserAlreadyRegistered(studentDto.UserDto))
                {
                    ViewBag.ErrorMsg = "Account is already registered. Try with a different Username";
                    return View();
                }

                studentDto.UserDto.Usertype = (byte)PMSEnums.UserType.STUDENT;
                studentDto.UserDto.CreatedOn = DateTime.Now;
                studentDto.UserDto.Status = (byte)PMSEnums.RecordStatus.ACTIVE;
                studentDto.CreatedOn = DateTime.Now;
                studentDto.Status = (byte)PMSEnums.RecordStatus.ACTIVE;
                _studentBLL.CreateStudent(studentDto);

                // setting student detail session
                LoggedInUserVM userVm = new LoggedInUserVM();
                userVm.UserType = (byte)PMSEnums.UserType.STUDENT;
                userVm.UserName = studentDto.UserDto.Username;
                userVm.StudentDto = studentDto;
                HttpContext.Session.SetObject("LoggedInUser", userVm);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
