using PMS.BOL;
using System.Collections.Generic;

namespace PMS.BLL
{
    public interface IPlacementDriveBLL
    {
        PlacementDriveDto GetPlacementDriveByCompanyId(int CompanyId);
        PlacementDriveDto GetPlacementDriveByCollegeId(int CollegeId);
        List<PlacementDriveDto> GetAllPlacementDrivebll();
        PlacementDriveDto GetPlacementDriveByPlacementDriveId(int PlacementDriveId);
        bool UpdatePlacementDrive(PlacementDriveDto placementDriveDto);
        bool DeletePlacementDrive(int PlacementDriveId);
        bool CreatePlacementDrive(PlacementDriveDto placementDriveDto);
    }
}