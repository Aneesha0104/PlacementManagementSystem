using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL
{
    public class PlacementAllocationRepository : GenericRepository<PlacementAllocation>, IPlacementAllocationRepository
    {
        public PlacementAllocationRepository(PmsdbContext context) : base(context)
        {
        }
    }
}
