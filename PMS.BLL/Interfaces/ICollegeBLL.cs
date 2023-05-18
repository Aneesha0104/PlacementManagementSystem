using PMS.BOL;
using System.Collections.Generic;

namespace PMS.BLL
{
    public interface ICollegeBLL
    {
        CollegeDto GetCollegeByUserId(int userId);
        List<CollegeDto> GetAllCollegeBll();
    }
}