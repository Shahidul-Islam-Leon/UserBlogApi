using BlogApi.Models;
using BlogApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApi.Repositories
{


    public class PostRepository : Repository<Post>
    {
        public List<Post> getAllPostByUser(int id)
        {
            return this.GetAllData().Where(x => x.UserId == id).ToList();
        }


        public Post GetUsernameByPost(string username)
        {
            return this.GetAllData().Where(x => x.User.Username == username).FirstOrDefault();
        }
    }
}
