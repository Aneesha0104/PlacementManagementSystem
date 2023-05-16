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
        public UserDto GetUserByCredentials(UserDto userDto)
        {
            var _userDto = new UserDto();
            var user = _userRepository.FirstOrDefault(x => x.Username == userDto.Username && x.Password==userDto.Password);
            if (user != null) CopyToDto(user, userDto);
            return userDto;
        }
        public bool CheckUserAlreadyRegistered(UserDto userDto)
        {
            var _userDto = new UserDto();
            var user = _userRepository.FirstOrDefault(x => x.Username == userDto.Username );
            return user != null;
        }
        public void CreateStudent(UserDto student)
        {
            var user = new User();
            CopyFromDto(student, user);
            _userRepository.Insert(user);
        }
        #region Copy 
        void CopyFromDto(UserDto source, User target)
        {
            target.Username = source.Username;
            target.Password = source.Password;  
            target.Usertype = source.Usertype;
            target.Status = source.Status;
            target.CreatedOn = source.CreatedOn;
        }
        void CopyToDto(User source, UserDto target)
        {
            target.Username = source.Username;
            target.Password = source.Password;
            target.Usertype = source.Usertype;
            target.UserId = source.UserId;
        }
        #endregion
    }
}
