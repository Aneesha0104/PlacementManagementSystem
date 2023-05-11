using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.BLL.Settings
{
  public class MailSettings
  {
    public string Mail { get; set; }
    public List<string> ToEmail { get; set; }
    public List<string> CCEmail { get; set; }
    public List<string> BCCEmail { get; set; }
    public string DisplayName { get; set; }
    public string Password { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
  }
}

