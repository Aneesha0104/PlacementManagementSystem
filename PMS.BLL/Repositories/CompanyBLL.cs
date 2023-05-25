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
        public CompanyDto GetCompanyByCompanyId(int companyID)
        {
            var company = _companyRepository.FirstOrDefault(x => x.CompanyId == companyID, include: x => x.Include(y => y.User));
            var companyDto = new CompanyDto();
            if (company != null) CopyToDto(company, companyDto);
            return companyDto;
        }
        public bool UpdateCompany(CompanyDto companyDto)
        {
            try
            {
                var company = _companyRepository.FirstOrDefault(x => x.CompanyId == companyDto.CompanyId, include: x => x.Include(y => y.User));
                CopyFromDto(companyDto, company);
                _companyRepository.Update(company);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteCompany(int companyId)
        {
            try
            {
                var company = _companyRepository.FirstOrDefault(x => x.CompanyId == companyId);
                company.Status = (byte)PMSEnums.RecordStatus.DELETE;
                _companyRepository.Update(company);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CreateCompany(CompanyDto companyDto)
        {
            try
            {
                var company = new Company();
                CopyFromDto(companyDto, company);
                _companyRepository.Insert(company);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #region Copy 
        void CopyFromDto(CompanyDto source, Company target)
        {
            target.Name = source.Name;           
            target.Branches = source.Branches;
            target.Remarks = source.Remarks;
            target.Location = source.Location;  
            target.Address = source.Address;            
            target.ContactNo = source.ContactNo;
            target.Website = source.Website;
            target.EmailId = source.EmailId;
            target.CreatedOn = DateTime.Now;
            target.Status = (byte)PMSEnums.RecordStatus.ACTIVE;
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
            target.CompanyId = source.CompanyId;
            target.Branches = source.Branches;
            target.Remarks = source.Remarks;
            target.Location = source.Location;
            target.Address = source.Address;            
            target.ContactNo = source.ContactNo;
            target.Website = source.Website;
            target.EmailId = source.EmailId;
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
