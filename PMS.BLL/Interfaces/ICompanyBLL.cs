using PMS.BOL;
using System.Collections.Generic;


namespace PMS.BLL
{
    public interface ICompanyBLL
    {
        CompanyDto GetCompanyByUserId(int userId);
        List<CompanyDto> GetAllCompanyBll();
        CompanyDto GetCompanyByCompanyId(int companyID);
        bool UpdateCompany(CompanyDto companyDto);
        bool CreateCompany(CompanyDto companyDto);
        bool DeleteCompany(int companyid);
    }
}