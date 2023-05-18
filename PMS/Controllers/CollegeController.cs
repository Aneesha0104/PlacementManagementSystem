using Microsoft.AspNetCore.Mvc;
using PMS.BLL;

namespace PMS.Controllers
{
    public class CollegeController : Controller
    {
        ICollegeBLL _collegeBll;
        public CollegeController(ICollegeBLL collegeBLL)
        {
            _collegeBll= collegeBLL;
        }
        public IActionResult Index()
        {
            var collegeList = _collegeBll.GetAllCollegeBll();
            return View(collegeList);
        }
    }
}
