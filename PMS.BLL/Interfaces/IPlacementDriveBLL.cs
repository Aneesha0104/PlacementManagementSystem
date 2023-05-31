using PMS.BOL;
using System.Collections.Generic;

namespace PMS.BLL
{
    public interface IPlacementDriveBLL
    {
        PlacementDriveDto GetPlacementDriveByCompanyId(int CompanyId);
        public PlacementDriveDto GetPlacementDriveByCollegeId(int collegeId);
        List<PlacementDriveDto> GetAllPlacementDrivebll();
        PlacementDriveDto GetPlacementDriveByPlacementDriveId(int PlacementDriveId);
        bool UpdatePlacementDrive(PlacementDriveDto placementDriveDto);
        bool DeletePlacementDrive(int PlacementDriveId);
        bool CreatePlacementDrive(PlacementDriveDto placementDriveDto);
    }
}