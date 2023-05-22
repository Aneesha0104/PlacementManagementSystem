using PMS.BOL;
using System.Collections.Generic;


namespace PMS.BLL
{
    public interface ICompanyBLL
    {
        CompanyDto GetCompanyByUserId(int userId);
        List<CompanyDto> GetAllCompanyBll();
    }
}