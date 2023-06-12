using System;
namespace PMS.BOL
{
    public class CommentDto
    {
        public int CommentId { get; set; }

        public int PlacementAllocationId { get; set; }

        public string CommentForOrg { get; set; }

        public string CommentForStudent { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte Status { get; set; }

        public PlacementAllocationDto PlacementAllocationDto { get; set; }

    }
}