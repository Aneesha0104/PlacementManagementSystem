using System;
using System.Collections.Generic;

namespace PMS.DAL.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public int CollegeId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedOn { get; set; }

    public byte Status { get; set; }

    public virtual College College { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
