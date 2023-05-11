using System;
using System.Collections.Generic;

namespace PMS.DAL.Models;

public partial class College
{
    public int CollegeId { get; set; }

    public string CollegeName { get; set; }

    public string Address { get; set; }

    public string Location { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedOn { get; set; }

    public byte Status { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<PlacementDrive> PlacementDrives { get; set; } = new List<PlacementDrive>();

    public virtual User User { get; set; }
}
