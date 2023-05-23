using Microsoft.AspNetCore.Mvc;
using PMS.BLL;

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
    }
}
