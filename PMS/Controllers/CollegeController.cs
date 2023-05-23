using Microsoft.AspNetCore.Mvc;
using PMS.BLL;
using PMS.BOL;

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
        public IActionResult Edit(int id)
        {
            ViewBag.ErrorCnfMsg = null;
            var college = _collegeBll.GetCollegeByCollegeId(id);
            return View(college);
        }
        [HttpPost]
        public IActionResult Edit(CollegeDto collegeDto)
        {
            if(ModelState.IsValid)
            {
                 _collegeBll.UpdateCollege(collegeDto);
                return RedirectToAction("Index");
            }

            ViewBag.ErrorCnfMsg= ModelState["UserDto.ConfirmPassowrd"]?.Errors[0].ErrorMessage;
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.ErrorCnfMsg = null;
            var college = new CollegeDto();
            return View(college);
        }
        [HttpPost]
        public IActionResult Create(CollegeDto collegeDto)
        {
            if (ModelState.IsValid)
            {
                _collegeBll.CreateCollege(collegeDto);
                return RedirectToAction("Index");
            }

            ViewBag.ErrorCnfMsg = ModelState["UserDto.ConfirmPassowrd"]?.Errors[0].ErrorMessage;
            return View();
        }
        public IActionResult Delete(int id)
        {
            _collegeBll.DeleteCollege(id);
            return RedirectToAction("Index");
        }
    }
}
