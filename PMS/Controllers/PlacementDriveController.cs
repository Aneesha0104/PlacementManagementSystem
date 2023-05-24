﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMS.BLL;
using PMS.BOL;
using PMS.DAL.Models;

namespace PMS.Controllers
{
    public class PlacementDriveController : Controller
    {
        IPlacementDriveBLL _placementDriveBll;
        ICollegeBLL _collegeBll;

        public PlacementDriveController(IPlacementDriveBLL placementDriveBll,ICollegeBLL collegeBLL)
        {
            _placementDriveBll = placementDriveBll;
            _collegeBll = collegeBLL;
        }

        public IActionResult Index()
        {
            var placementdriveList = _placementDriveBll.GetAllPlacementDrivebll();
            return View(placementdriveList);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.collegeList = new SelectList(_collegeBll.GetAllCollegeBll(), "CollegeId", "CollegeName");
            var placementdrive = _placementDriveBll.GetPlacementDriveByPlacementDriveId(id);
            return View(placementdrive);
        }
        [HttpPost]
        public IActionResult Edit(PlacementDriveDto placementdriveDto)
        {
            if(ModelState.IsValid)
            {
                //var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
                

                _placementDriveBll.UpdatePlacementDrive(placementdriveDto);
                return RedirectToAction("Index");


            }
            ViewBag.ErrorCnfMsg = ModelState["UserDto.ConfirmPassword"]?.Errors[0].ErrorMessage;
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.collegeList= new SelectList(_collegeBll.GetAllCollegeBll(), "CollegeId", "CollegeName");
            var placementdrive=new PlacementDriveDto();
            return View(placementdrive);
        }
        [HttpPost]

        public IActionResult Create(PlacementDriveDto placementdriveDto)
        {
            if(ModelState.IsValid)
            {
                var loogedInUser = HttpContext.Session.GetObject<LoggedInUserVM>("LoggedInUser");
                if (loogedInUser?.CompanyDto != null) placementdriveDto.CompanyId = loogedInUser.CompanyDto.CompanyId;
                _placementDriveBll.CreatePlacementDrive(placementdriveDto);
                return RedirectToAction("Index");
            }
            ViewBag.ErrorCnfMsg = ModelState["UserDto.ConfirmPassword"]?.Errors[0].ErrorMessage;
            return View();
        }


    }

    
}
   
