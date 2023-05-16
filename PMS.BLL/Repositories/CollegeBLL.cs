using PMS.BOL;
using PMS.DAL;
using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public class CollegeBLL : ICollegeBLL
    {
        ICollegeRepository _collegeRepository;

        public CollegeBLL(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        public CollegeDto GetCollegeByUserId(int userId)
        {
            var college = _collegeRepository.FirstOrDefault(x => x.UserId == userId);
            var collegeDto=new CollegeDto();
            if (college == null) CopyToDto(college, collegeDto);
            return collegeDto;
        }
        #region Copy 
        void CopyFromDto(CollegeDto source, College target)
        {
            target.CollegeName = source.CollegeName;
            target.Location = source.Location;  
            target.Address = source.Address;
            target.CreatedOn = source.CreatedOn;
            target.Status = source.Status;
            target.UserId= source.UserId;
            if(source.UserDto !=null)
            {

                target.User = new User();
                target.User.Username=source.UserDto.Username;
                target.User.Password=source.UserDto.Password;
                target.User.CreatedOn = DateTime.Now;
                target.User.Usertype = (byte)PMSEnums.UserType.COLLEGE;
            }
        }
        void CopyToDto(College source, CollegeDto target)
        {
            target.CollegeName = source.CollegeName;
            target.Location = source.Location;
            target.Address = source.Address;
            target.CreatedOn = DateTime.Now;
            target.Status = source.Status;
            target.UserId = source.UserId;
            if (source.User != null)
            {
                target.UserDto = new UserDto();
                target.UserDto.Username = source.User.Username;
                target.UserDto.CreatedOn = DateTime.Now;
                target.UserDto.Usertype =source.User.Usertype;
            }
        }
        #endregion
    }
}
