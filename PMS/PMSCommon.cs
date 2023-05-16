using Newtonsoft.Json;
using PMS.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS
{
    public class PMSCommon
    {
      
    }
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
