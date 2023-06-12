using PMS.BOL;
using PMS.DAL;
using PMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PMS.BLL
{
    public class CommentBLL : ICommentBLL
    {
        ICommentRepository _commentRepository;
        IPlacementAllocationRepository _placementAllocationRepository;
        public CommentBLL(ICommentRepository commentRepository , IPlacementAllocationRepository placementAllocationRepository)
        {
            _commentRepository = commentRepository;
            _placementAllocationRepository = placementAllocationRepository;
        }

    }

    
}