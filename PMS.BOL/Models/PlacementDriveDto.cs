using System;

namespace PMS.BOL
{
    public class PlacementDriveDto 
    {
        public int PlacementDriveId { get; set; }

        public int CollegeId { get; set; }

        public int CompanyId { get; set; }

        public DateTime InterviewDate { get; set; }

        public int NoOfVacancies { get; set; }

        public string Package { get; set; }

        public string Place { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte Status { get; set; }
        public CollegeDto CollegeDto { get; set; }
        public CompanyDto CompanyDto { get; set; }

    }

}
