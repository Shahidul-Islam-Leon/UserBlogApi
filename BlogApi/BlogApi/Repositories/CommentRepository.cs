using BlogApi.Models;
using BlogApi.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogApi.Repositories
{
    public class CommentRepository:Repository<Comment>
    {
        private readonly BlogApiDbContext context = new BlogApiDbContext();
        public List<Comment> getAllCommentByPost(int id)
        {
            return this.GetAllData().Where(x => x.PostId == id).ToList();
        }

        public new Comment Get(int id)
        {
            return this.context.Comments.Where(x => x.CommentId == id).Include(x => x.Post).FirstOrDefault();
        }
    }
}
