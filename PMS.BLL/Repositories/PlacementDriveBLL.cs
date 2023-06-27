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
    public class PlacementDriveBLL : IPlacementDriveBLL
    {
        IPlacementDriveRepository _placementDriveRepository;
        ICollegeRepository _collegeRepository;
        ICompanyRepository _companyRepository;
        public PlacementDriveBLL(IPlacementDriveRepository placementDriveRepository,ICollegeRepository collegeRepository,ICompanyRepository companyRepository)
        {
            _placementDriveRepository = placementDriveRepository;
            _collegeRepository = collegeRepository;
            _companyRepository = companyRepository;
        }

        public List<PlacementDriveDto> GetPlacementDriveByCompanyId(int companyId)
        {
            var drives = _placementDriveRepository.GetAll(x => x.CompanyId == companyId, x=>x.College);
            var driveDtoList = new List<PlacementDriveDto>();

            if (drives != null)
            {
                foreach (var drive in drives)
                {
                    var driveDto = new PlacementDriveDto();
                    CopyToDto(drive, driveDto);
                    
                    driveDtoList.Add(driveDto);
                }
            }

            return driveDtoList;
        }

        public List<PlacementDriveDto> GetPlacementDriveByCollegeId(int collegeId)
        {
            var placementdrive = _placementDriveRepository.GetAll(x => x.CollegeId == collegeId && x.Status == (byte)PMSEnums.RecordStatus.ACTIVE,x=>x.College,x=>x.Company);
            var placementdriveDto = new List<PlacementDriveDto>();
            if (placementdrive != null)
            {
                foreach (var item in placementdrive)
                {
                    var placement = new PlacementDriveDto();
                    CopyToDto(item, placement);
                    placementdriveDto.Add(placement);
                }
            }

            return placementdriveDto;

        }


        public List<PlacementDriveDto> GetAllPlacementDrivebll()
        {
            var placementdrive = _placementDriveRepository.GetAll(x => x.Status == (byte)PMSEnums.RecordStatus.ACTIVE, x => x.College,x => x.Company);
            var placementdriveDtoList = new List<PlacementDriveDto>();
            if (placementdrive != null) { }
            {
                foreach (var item in placementdrive)
                {
                    var placementdriveDto = new PlacementDriveDto();
                    CopyToDto(item, placementdriveDto);
                    placementdriveDtoList.Add(placementdriveDto);
                }
            }
            return placementdriveDtoList;
        }
        public PlacementDriveDto GetPlacementDriveByPlacementDriveId(int placementdriveID)
        {
            var placementdrive = _placementDriveRepository.FirstOrDefault(x => x.PlacementDriveId == placementdriveID, include: x => x.Include(y => y.Company));
            var placementdriveDto = new PlacementDriveDto();
            if (placementdrive != null) CopyToDto(placementdrive, placementdriveDto);
            return placementdriveDto;
        }
        public bool UpdatePlacementDrive(PlacementDriveDto placementdriveDto)
        {
            try
            {
                var placementdrive = _placementDriveRepository.FirstOrDefault(x => x.PlacementDriveId == placementdriveDto.PlacementDriveId, include: x => x.Include(y => y.Company));
                CopyFromDto(placementdriveDto, placementdrive);
                _placementDriveRepository.Update(placementdrive);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool InactivePlacementDrive(int placementdriveId)
        {
            try
            {
                var placementdrive = _placementDriveRepository.FirstOrDefault(x => x.PlacementDriveId == placementdriveId);
                placementdrive.Status = (byte)PMSEnums.RecordStatus.INACTIVE;
               
                _placementDriveRepository.Update(placementdrive);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActivePlacementDrive(int placementdriveId)
        {
            try
            {
                var placementdrive = _placementDriveRepository.FirstOrDefault(x => x.PlacementDriveId == placementdriveId);
                placementdrive.Status = (byte)PMSEnums.RecordStatus.ACTIVE;

                _placementDriveRepository.Update(placementdrive);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool CreatePlacementDrive(PlacementDriveDto placementdriveDto)
        {
            try
            {
                var placementdrive = new PlacementDrive();
                CopyFromDto(placementdriveDto, placementdrive);
                _placementDriveRepository.Insert(placementdrive);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetPlacementDriveCount(int companyID)
        {
            return companyID == 0

                ? _placementDriveRepository.GetRecordCount(u => u.Status == (byte)PMSEnums.RecordStatus.ACTIVE)
                : _placementDriveRepository.GetRecordCount(u => u.Status == (byte)PMSEnums.RecordStatus.ACTIVE && u.CompanyId == companyID);
        }

        public int GetPlacementDriveCountByCollege(int collegeID)
        {
            return collegeID == 0

                ? _placementDriveRepository.GetRecordCount(u => u.Status == (byte)PMSEnums.RecordStatus.ACTIVE)
                : _placementDriveRepository.GetRecordCount(u => u.Status == (byte)PMSEnums.RecordStatus.ACTIVE && u.CollegeId == collegeID);
        }


        



        #region Copy 
        void CopyFromDto(PlacementDriveDto source, PlacementDrive target)
        {
            target.InterviewDate = source.InterviewDate;
            target.NoOfVacancies = source.NoOfVacancies;
            target.Package = source.Package;
            target.CreatedOn = DateTime.Now;
            target.Place = source.Place;
            target.Title = source.Title;
            target.Details = source.Details;
            target.CollegeId = source.CollegeId;
            target.CompanyId = source.CompanyId;
            target.Status = (byte)PMSEnums.RecordStatus.ACTIVE;
        }
        void CopyToDto(PlacementDrive source, PlacementDriveDto target)
        {
            target.InterviewDate = source.InterviewDate;
            target.NoOfVacancies = source.NoOfVacancies;
            target.Package = source.Package;
            target.CreatedOn = DateTime.Now;
            target.Place = source.Place;
            target.Title = source.Title;
            target.Details = source.Details;
            target.Status = source.Status;
            target.PlacementDriveId = source.PlacementDriveId;
            target.CollegeId = source.CollegeId;
            target.CompanyId = source.CompanyId;
            target.CollegeDto = new CollegeDto();
            if (source.College != null)
            {
                target.CollegeDto.CollegeName = source.College.CollegeName;
            }
            target.CompanyDto = new CompanyDto();
            if (source.Company != null)
            {
                target.CompanyDto.Name = source.Company.Name;
            }

        }
        #endregion
    }
}




