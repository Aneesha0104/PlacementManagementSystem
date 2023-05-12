using System;

namespace PMS.BOL
{
    public class AcademicDetailDto
    {
        public int AcademicDetailId { get; set; }

        public int Percentage10th { get; set; }

        public DateTime PassOutYear10th { get; set; }

        public string School10th { get; set; }

        public int? Percentage12th { get; set; }

        public DateTime? PassOutYear12th { get; set; }

        public string School12th { get; set; }

        public int? DegreePercentage { get; set; }

        public DateTime? PassOutYearDegree { get; set; }

        public string CollegeDegree { get; set; }

        public int? PgPercentage { get; set; }

        public DateTime? PassOutYearPg { get; set; }

        public string CollegePg { get; set; }

        public byte Status { get; set; }

    }
}