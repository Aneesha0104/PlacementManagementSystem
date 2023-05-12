using PMS.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL
{
    public interface IUserBLL
    {
        UserDto GetUserByID(int id);
        UserDto GetUserByCredentials(UserDto userDto);
    }
}
