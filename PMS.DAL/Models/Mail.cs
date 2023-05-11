using System;
using System.Collections.Generic;

namespace PMS.DAL.Models;

public partial class Mail
{
    public string MailId { get; set; }

    public string ToId { get; set; }

    public string FromId { get; set; }

    public string Subject { get; set; }

    public string Message { get; set; }

    public DateTime? Date { get; set; }

    public string Flag { get; set; }
}
