using System;
using System.Collections.Generic;

namespace PMS.DAL.Models;

public partial class PlacementAllocation
{
    public int PlacementAllocationId { get; set; }

    public int PlacementDriveId { get; set; }

    public int StudentId { get; set; }

    public int? CommentId { get; set; }

    public string Rating { get; set; }

    /// <summary>
    /// Scheduled, Passed , Failed
    /// </summary>
    public byte PlacementStatus { get; set; }

    public virtual Comment Comment { get; set; }

    public virtual PlacementDrive PlacementDrive { get; set; }

    public virtual Student Student { get; set; }
}
