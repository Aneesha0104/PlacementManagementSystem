using PMS.BOL;
using System.Collections.Generic;

namespace PMS.BLL
{
    public interface IPlacementAllocationBLL
    {
        PlacementAllocationDto GetPlacementAllocationByPlacementAllocationId(int placementAllocationId);
        PlacementAllocationDto GetPlacementAllocationByStudentId(int studentId);
        PlacementAllocationDto GetPlacementAllocationByPlacementDriveId(int placementDriveId);
        List<PlacementAllocationDto> GetAllPlacementAllocationbll();
        bool AllocatePlacementDriveToStudent(List<StudentDto> studentDto, int pId);
        List<PlacementAllocationDto> GetAllAllocatedStudent(int placementDriveId);









    }

}