using System;

namespace PMS.BOL
{
    public class PlacementAllocationDto
    {
        public int PlacementAllocationId { get; set; }

        public int PlacementDriveId { get; set; }

        public int StudentId { get; set; }

        public int? CommentId { get; set; }

        public string Rating { get; set; }

        public byte PlacementStatus { get; set; }
        public StudentDto StudentDto { get; set; }
        public PlacementDriveDto PlacementDriveDto { get; set; }
        public CommentDto CommentDto { get; set; }


    }
}