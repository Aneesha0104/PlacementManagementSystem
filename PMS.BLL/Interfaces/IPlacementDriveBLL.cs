using PMS.BOL;
using System.Collections.Generic;

namespace PMS.BLL
{
    public interface IPlacementDriveBLL
    {
        public List<PlacementDriveDto> GetPlacementDriveByCompanyId(int companyId);
        public List<PlacementDriveDto> GetPlacementDriveByCollegeId(int collegeId);
        List<PlacementDriveDto> GetAllPlacementDrivebll();
        PlacementDriveDto GetPlacementDriveByPlacementDriveId(int PlacementDriveId);
        bool UpdatePlacementDrive(PlacementDriveDto placementDriveDto);
        public bool InactivePlacementDrive(int placementdriveId);
        public bool ActivePlacementDrive(int placementdriveId);
        bool CreatePlacementDrive(PlacementDriveDto placementDriveDto);
    }
}