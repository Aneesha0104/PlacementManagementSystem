using PMS.BOL;

namespace PMS.BLL
{
    public interface ICollegeBLL
    {
        CollegeDto GetCollegeByUserId(int userId);
    }
}