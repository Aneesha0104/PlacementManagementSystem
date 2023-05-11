using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PmsdbContext context) : base(context)
        {
        }
    }
}
 