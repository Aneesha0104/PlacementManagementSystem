using PMS.BOL;
using System.Collections.Generic;

namespace PMS.BLL
{
    public interface ICollegeBLL
    {
        CollegeDto GetCollegeByUserId(int userId);
        List<CollegeDto> GetAllCollegeBll();
         CollegeDto GetCollegeByCollegeId(int collegeID);
        bool UpdateCollege(CollegeDto collegeDto);
        bool CreateCollege(CollegeDto collegeDto);
        bool DeleteCollege(int collegeId);
        //public int GetStudentCountByCollegeId(int collegeID);
    }
}