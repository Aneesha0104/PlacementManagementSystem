using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    [NotMapped]
    [Compare("Password", ErrorMessage = "Confirm  Password doesn't match, Try again !")]
    public string ConfirmPassowrd { get; set; }
    public byte Usertype { get; set; }

    public DateTime CreatedOn { get; set; }

    public byte Status { get; set; }

    public virtual ICollection<College> Colleges { get; set; } = new List<College>();

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
