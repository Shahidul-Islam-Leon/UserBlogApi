using BlogApi.Models;
using BlogApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    public class PostController : ApiController
    {
        PostRepository pr = new PostRepository();
        public IHttpActionResult Get()
        {
            return Ok(pr.GetAllData());
        }
        public IHttpActionResult Post(Post post)
        {
            pr.Insert(post);
            return Created("api/Users/" + post.PostId, post);
        }

        public IHttpActionResult Get(int id)
        {
            var post = pr.Get(id);

            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(post);
        }

        public IHttpActionResult Put([FromUri] int id, [FromBody] Post post)
        {
            post.UserId = id;
            pr.Update(post);
            return Ok(post);
        }

        public IHttpActionResult Delete(int id)
        {
            pr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

