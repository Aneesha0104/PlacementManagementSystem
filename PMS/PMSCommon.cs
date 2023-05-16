using Newtonsoft.Json;
using PMS.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.DAL
{
    public class PMSCommon
    {
       public LoggedInUserVM GetCurrentUser(HttpContext httpContext)
        {
            if(httpContext.Session.GetString("LoggedInUser")!=null)
            {
                return JsonConvert.DeserializeObject<LoggedInUserVM>(httpContext.Session.GetString("LoggedInUser"));
            }
            return null;    
        }
    }
}
