using PMS.BOL;
using PMS.DAL;
using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PMS.BLL
{
    public class CompanyBLL : ICompanyBLL
    {
        ICompanyRepository _companyRepository;

        public CompanyBLL(ICompanyRepository companyRepository)
        {
            _companyRepository  = companyRepository;
        }

        public CompanyDto GetCompanyByUserId(int userId)
        {
            var company = _companyRepository.FirstOrDefault(x => x.UserId == userId);
            var companyDto=new CompanyDto();
            if (company != null) CopyToDto(company, companyDto);
            return companyDto;
        }
        public List<CompanyDto> GetAllCompanyBll()
        {
            var company = _companyRepository.GetAll(x => x.Status == (byte)PMSEnums.RecordStatus.ACTIVE, x => x.User);
            var companyDtoList = new List<CompanyDto>();
            if (company != null)
            {
                foreach (var item in company)
                {
                    var companyDto = new CompanyDto();
                    CopyToDto(item, companyDto);
                    companyDtoList.Add(companyDto);
                }
            }
            return companyDtoList;
        }
        #region Copy 
        void CopyFromDto(CompanyDto source, Company target)
        {
            target.Name = source.Name;
            target.Website = source.Website;
            target.Branches = source.Branches;
            target.Remarks = source.Remarks;
            target.Location = source.Location;  
            target.Address = source.Address;
            target.CreatedOn = DateTime.Now;
            target.Status = source.Status;
            target.UserId= source.UserId;
            if(source.UserDto !=null)
            {
                target.User = new User();
                target.User.Username=source.UserDto.Username;
                target.User.Password=source.UserDto.Password;
                target.User.CreatedOn = DateTime.Now;
                target.User.Usertype = (byte)PMSEnums.UserType.COMPANY;
            }
        }
        void CopyToDto(Company source, CompanyDto target)
        {
            target.Name = source.Name;
            target.Website = source.Website;
            target.CompanyId = source.CompanyId;
            target.Branches = source.Branches;
            target.Remarks = source.Remarks;
            target.Location = source.Location;
            target.Address = source.Address;
            target.CreatedOn = source.CreatedOn;
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
