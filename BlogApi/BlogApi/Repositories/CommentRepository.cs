using BlogApi.Models;
using BlogApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApi.Repositories
{
    public class CommentRepository:Repository<Comment>
    {

        public List<Comment> getAllCommentByPost(int id)
        {
            return this.GetAllData().Where(x => x.PostId == id).ToList();
        }
    }
}
