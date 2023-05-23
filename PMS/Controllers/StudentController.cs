using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMS.BLL;

namespace PMS.Controllers
{
    public class StudentController : Controller
    {
        IStudentBLL _studentBLL;
        public StudentController(IStudentBLL studentBLL)
        {
            _studentBLL = studentBLL;
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
        public ActionResult GetDepartments(String college)
        {
            if(!string.IsNullOrEmpty(college))
            {
                //List<SelectListItem> department = 
            }
            return null;
        }
    }
}
