using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BOL
{
    public static class PMSEnums
    {
        public enum RecordStatus : byte
        {
           
            [EnumTextValue("Inactive")]
            INACTIVE,
            [EnumTextValue("Active")]
            ACTIVE,
            [EnumTextValue("Delete")]
            DELETE

        }
        public enum UserType : byte
        {
            [EnumTextValue("Admin")]
            ADMIN,
            [EnumTextValue("Student")]
            STUDENT,
            [EnumTextValue("College")]
            COLLEGE,
            [EnumTextValue("Company")]
            COMPANY

        }
        public enum PlacementStatus : byte
        {

            [EnumTextValue("Allocated")]
            ALLOCATED,
            [EnumTextValue("Placed")]
            PLACED,
            [EnumTextValue("Rejected")]
            REJECTED

        }


        public static string GetTextValue(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumTextValue), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((EnumTextValue)attrs[0]).Text;
                }
            }
            return en.ToString();
        }

        public static IList ToList(this Type type)
        {
            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetTextValue(value)));
            }
            return list;
        }

        public static KeyValuePair<Enum, string> GetKeyValuePair(Enum em)
        {
            return new KeyValuePair<Enum, string>(em, GetTextValue(em));
        }
    }

    internal sealed class EnumTextValue : Attribute
    {
        public string Text;

        public EnumTextValue(string text)
        {
            Text = text;
        }
    }

}