using PMS.BOL;
using PMS.DAL;
using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;
using static PMS.BOL.PMSEnums;

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
            var college = _collegeRepository.FirstOrDefault(x => x.UserId == userId,include: x=>x.Include(y=>y.User));
            var collegeDto=new CollegeDto();
            if (college != null) CopyToDto(college, collegeDto);
            return collegeDto;
        }
        public List<CollegeDto> GetAllCollegeBll()
        {
            var college = _collegeRepository.GetAll(x => x.Status == (byte)PMSEnums.RecordStatus.ACTIVE,x=>x.User);
            var collegeDtoList = new List<CollegeDto>();
            if (college != null)
            {
                foreach(var item in college)
                {
                    var collegeDto =new CollegeDto();
                    CopyToDto(item, collegeDto);
                    collegeDtoList.Add(collegeDto);
                }
            }
            return collegeDtoList;
        }
        public CollegeDto GetCollegeByCollegeId(int collegeID)
        {
            var college = _collegeRepository.FirstOrDefault(x => x.CollegeId == collegeID, include: x => x.Include(y => y.User));
            var collegeDto = new CollegeDto();
            if (college != null) CopyToDto(college, collegeDto);
            return collegeDto;
        }
        public bool UpdateCollege(CollegeDto collegeDto)
        {
            try
            {
                var college = _collegeRepository.FirstOrDefault(x => x.CollegeId == collegeDto.CollegeId, include: x => x.Include(y => y.User));
                CopyFromDto(collegeDto, college);
                _collegeRepository.Update(college);
                return true;
            }
           catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteCollege(int collegeId)
        {
            try
            {
                var college = _collegeRepository.FirstOrDefault(x => x.CollegeId == collegeId);
                college.Status = (byte)PMSEnums.RecordStatus.DELETE;
                _collegeRepository.Update(college);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CreateCollege(CollegeDto collegeDto)
        {
            try
            {
                var college = new College();
                CopyFromDto(collegeDto, college);
                _collegeRepository.Insert(college);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        #region Copy 
        void CopyFromDto(CollegeDto source, College target)
        {
            target.CollegeName = source.CollegeName;
            target.Location = source.Location;  
            target.Address = source.Address;
            target.CreatedOn = DateTime.Now ;
            target.Status = (byte)PMSEnums.RecordStatus.ACTIVE;
            if (source.UserDto !=null)
            {

               target.User = target.User==null? new User() :target.User;
                target.User.Password= source.UserDto.Password !=null? source.UserDto.Password: target.User.Password;
                target.User.Username= source.UserDto.Username;
                target.User.CreatedOn = DateTime.Now;
                target.User.Usertype = (byte)PMSEnums.UserType.COLLEGE;
            }
        }
        void CopyToDto(College source, CollegeDto target)
        {
            target.CollegeName = source.CollegeName;
            target.Location = source.Location;
            target.Address = source.Address;
            target.CreatedOn = source.CreatedOn;
            target.Status = source.Status;
            target.UserId = source.UserId;
            target.CollegeId = source.CollegeId;
            if (source.User != null)
            {
                target.UserDto = new UserDto();
                target.UserDto.Username = source.User.Username;
                target.UserDto.CreatedOn =source.CreatedOn;
                target.UserDto.Usertype =source.User.Usertype;
            }
        }
        #endregion
    }
}
