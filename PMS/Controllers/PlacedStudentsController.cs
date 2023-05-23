using Microsoft.AspNetCore.Mvc;
using PMS.BLL;

namespace PMS.Controllers
{
    public class PlacedStudentsController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
