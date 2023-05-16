using PMS.BOL;

namespace PMS.BLL
{
    public interface ICompanyBLL
    {
        CompanyDto GetCompanyByUserId(int userId);
    }
}