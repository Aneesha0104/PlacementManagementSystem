using PMS.BOL;
using System.Collections.Generic;

namespace PMS.BLL
{
    public interface ICommentBLL
    {
        public CommentDto GetCommentByStudentId(int id);
    }

}