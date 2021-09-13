using BlogApi.Attributes;
using BlogApi.Models;
using BlogApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BlogApi.Controllers
{
    [RoutePrefix("api/Post")]
    public class PostController : ApiController
    {
        PostRepository pr = new PostRepository();
        [Route(""), UserAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(pr.GetAllData());
        }

        [Route(""),UserAuthentication]
        public IHttpActionResult Post(Post post)
        {
           
            string Uname = Thread.CurrentPrincipal.Identity.Name;
            pr.Insert(post);
            return Created("api/Users/" + post.PostId, post);
        }

        [Route("{id}"),UserAuthentication]
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
            post.PostId = id;
            pr.Update(post);
            return Ok(post);
        }

        public IHttpActionResult Delete(int id)
        {
            pr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        [Route("{id}/Comment")]
        public IHttpActionResult GetCommentByPostId(int id)
        {
            CommentRepository cr = new CommentRepository();
            return Ok(cr.getAllCommentByPost(id));
        }
    }
}


