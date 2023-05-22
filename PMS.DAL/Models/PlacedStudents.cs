using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.Models
{
    public partial class PlacedStudents
    {
        public int PSId { get; set; }
        public string StudentName { get; set; }
        public string Department { get; set;}
        public string Course { get; set;}
        public string CompanyName { get; set;}
        public string Designation { get; set;}
        public string CompanyAddress { get; set;}
        public string CompanyCity { get; set;}
        public string CompanyEmail { get; set;}
        public string CompanyPhone { get; set;}
        public string StudentPhone { get; set; }
        public string StudentsEmail { get; set;}

        public virtual User User { get; set; }
        

    }
}
