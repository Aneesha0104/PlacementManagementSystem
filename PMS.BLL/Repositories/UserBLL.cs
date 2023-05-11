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
    public class UserBLL : IUserBLL
    {
        IUserRepository _userRepository;

        public UserBLL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto GetUserByID(int Id)
        {
            var userDto = new UserDto();
            var user = _userRepository.FirstOrDefault(x => x.UserId == Id);
            if (user != null) CopyToDto(user, userDto); 
            return userDto; 
        }
        #region Copy 
        void CopyFromDto(UserDto source, User target)
        {
            target.Username = source.Username;
            target.Password = source.Password;  
            target.Usertype = source.Usertype;
        }
        void CopyToDto(User source, UserDto target)
        {
            target.Username = source.Username;
            target.Password = source.Password;
            target.Usertype = source.Usertype;
        }
        #endregion
    }
}
