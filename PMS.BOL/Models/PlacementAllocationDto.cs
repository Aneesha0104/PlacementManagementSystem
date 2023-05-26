using System;

namespace PMS.BOL
{
    public class PlacementAllocationDto
    {
        public int PlacementAllocationId { get; set; }

        public int PlacementDriveId { get; set; }

        public int StudentId { get; set; }

        public string CommentId { get; set; }

        public string Rating { get; set; }

        public byte PlacementStatus { get; set; }
        public StudentDto Student { get; set; }
        public PlacementDriveDto PlacementDrive { get; set; }

    }
}