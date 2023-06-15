using Microsoft.AspNetCore.Mvc;
using PMS.BLL;
using PMS.BOL;

namespace PMS.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyBLL _CompanyBll;
        public CompanyController(ICompanyBLL companyBLL)
        {
            _CompanyBll = companyBLL;
        }
        public IActionResult Index()
        {
            var companyList = _CompanyBll.GetAllCompanyBll();
            return View(companyList);
        }


        public IActionResult Edit(int id)
        {
            ViewBag.ErrorCnfMsg = null;
            var college = _CompanyBll.GetCompanyByUserId(id);
            return View(college);
        }
        [HttpPost]
        public IActionResult Edit(CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                _CompanyBll.UpdateCompany(companyDto);
                return RedirectToAction("Index");
            }

            ViewBag.ErrorCnfMsg = ModelState["UserDto.ConfirmPassowrd"]?.Errors[0].ErrorMessage;
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.ErrorCnfMsg = null;
            var company = new CompanyDto();
            return View(company);
        }
        [HttpPost]
        public IActionResult Create(CompanyDto companyDto)
        {
            if (ModelState.IsValid)
            {
                _CompanyBll.CreateCompany(companyDto);
                return RedirectToAction("Index");
            }

            ViewBag.ErrorCnfMsg = ModelState["UserDto.ConfirmPassowrd"]?.Errors[0].ErrorMessage;
            return View();
        }
        public IActionResult Delete(int id)
        {
            _CompanyBll.DeleteCompany(id);
            return RedirectToAction("Index");
        }
    }
}
