using PMS.BOL;
using PMS.DAL;
using PMS.DAL.Models;
using System.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static PMS.BOL.PMSEnums;

namespace PMS.BLL
{
    public class UserBLL : IUserBLL
    {
        IUserRepository _userRepository;
        IHttpContextAccessor _httpContextAccessor;
        ICollegeRepository _collegeRepository;
        

        public UserBLL(IUserRepository userRepository,IHttpContextAccessor httpContextAccessor,ICollegeRepository collegeRepository)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _collegeRepository = collegeRepository;
            
            
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
            var user = _userRepository.FirstOrDefault(x => x.Username == userDto.Username );
            return user != null;
        }
        public void Logout()
        {
            var httpcontext = _httpContextAccessor.HttpContext;
            httpcontext.SignOutAsync();
            httpcontext.Session.Clear();
        }
        

        public int GetStudentCount()
        {
            return _userRepository.GetRecordCount(u=>u.Usertype==(byte)UserType.STUDENT);
        }

        public int GetCollegeCount()
        {
            return _userRepository.GetRecordCount(u=>u.Usertype==(byte)UserType.COLLEGE);
        }

        public int GetCompanyCount()
        {
            return _userRepository.GetRecordCount(u => u.Usertype == (byte)UserType.COMPANY);
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
