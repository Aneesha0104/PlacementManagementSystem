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
using Org.BouncyCastle.Math.EC.Rfc7748;
using Microsoft.AspNetCore.Mvc;

namespace PMS.BLL
{
    public class PlacementAllocationBLL : IPlacementAllocationBLL
    {
        IPlacementAllocationRepository _placementAllocationRepository;
        public PlacementAllocationBLL(IPlacementAllocationRepository placementAllocationRepository)
        {
            _placementAllocationRepository = placementAllocationRepository;
        }

        public PlacementAllocationDto GetPlacementAllocationByPlacementAllocationId(int placementAllocationId)
        {
            var placementAllocation = _placementAllocationRepository.FirstOrDefault(x => x.PlacementAllocationId == placementAllocationId, include: x => x.Include(y => y.Student));
            var placementAllocationDto = new PlacementAllocationDto();
            if (placementAllocation != null) CopyToDto(placementAllocation, placementAllocationDto);
            return placementAllocationDto;
        }
         public PlacementAllocationDto GetPlacementAllocationByPlacementDriveId(int placementDriveId)
        {
            var placementAllocation = _placementAllocationRepository.FirstOrDefault(x => x.PlacementDriveId==placementDriveId,include:x=>x.Include(y => y.PlacementDrive));
            var placementAllocationDto = new PlacementAllocationDto();
            if(placementAllocation!=null) CopyToDto(placementAllocation,placementAllocationDto);
            return placementAllocationDto;
        }

        public PlacementAllocationDto GetPlacementAllocationByStudentId(int studentId)
        {
            var placementAllocation = _placementAllocationRepository.FirstOrDefault(x => x.StudentId == studentId, include: x => x.Include(y => y.Student));
            var placementAllocationDto = new PlacementAllocationDto();
            if (placementAllocation != null) CopyToDto(placementAllocation, placementAllocationDto);
            return placementAllocationDto;
        }

        public List<PlacementAllocationDto> GetAllPlacementAllocationbll()
        {
            var placementAllocation = _placementAllocationRepository.GetAll(x => x.PlacementStatus == (byte)PMSEnums.RecordStatus.ACTIVE, x => x.Student, x => x.PlacementDrive);
            var placementAllocationDtoList = new List<PlacementAllocationDto>();
            if (placementAllocation != null) { }
            {
                foreach (var item in placementAllocation)
                {
                    var placementAllocationDto = new PlacementAllocationDto();
                    CopyToDto(item, placementAllocationDto);
                    placementAllocationDtoList.Add(placementAllocationDto);
                }
            }
            return placementAllocationDtoList;
        }
        

        void CopyFromDto(PlacementAllocationDto source,PlacementAllocation target)
        {
            target.Rating = source.Rating;
            target.PlacementStatus = source.PlacementStatus;


        }
        void CopyToDto (PlacementAllocation source,PlacementAllocationDto target)
        {
            target.PlacementAllocationId= source.PlacementAllocationId;
            target.PlacementDriveId= source.PlacementDriveId;
            target.PlacementStatus = source.PlacementStatus;
            target.StudentId= source.StudentId;
            target.CommentId= source.CommentId;
            target.StudentDto = new StudentDto();
            target.StudentDto.Name = source.Student?.Name;
            target.PlacementDriveDto = new PlacementDriveDto();
            target.PlacementDriveDto.CompanyDto.Name = source.PlacementDrive.Company.Name;

            
        }

    }
    
}