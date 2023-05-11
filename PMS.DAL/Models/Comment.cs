using System;
using System.Collections.Generic;

namespace PMS.DAL.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int PlacementAllocationId { get; set; }

    public string CommentForOrg { get; set; }

    public string CommentForStudent { get; set; }

    public DateTime CreatedOn { get; set; }

    public byte Status { get; set; }

    public virtual PlacementAllocation PlacementAllocation { get; set; }
}
