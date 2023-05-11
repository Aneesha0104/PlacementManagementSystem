using System;
using System.Collections.Generic;

namespace PMS.DAL.Models;

public partial class PlacementDrive
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

    public virtual College College { get; set; }

    public virtual Company Company { get; set; }

    public virtual ICollection<PlacementAllocation> PlacementAllocations { get; set; } = new List<PlacementAllocation>();
}
