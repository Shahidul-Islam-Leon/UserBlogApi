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
    [RoutePrefix("api/Posts")]
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

            string Uname = Thread.CurrentPrincipal.Identity.Name;
            var getById = pr.Get(id);
            var username = getById.User.Username;

            if(Uname==username)
            {
                pr.Update(post);
                return Ok(post);
            }
            else
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
           
        }

        [Route("{id}"), UserAuthentication]
        public IHttpActionResult Delete(int id)
        {
            
            string Uname = Thread.CurrentPrincipal.Identity.Name;
            var getById = pr.Get(id);
            var username = getById.User.Username;


            if (Uname==username)
            {
                pr.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }
        
        }


        [Route("{id}/Comment")]
        public IHttpActionResult GetCommentByPostId(int id)
        {
            CommentRepository cr = new CommentRepository();
            return Ok(cr.getAllCommentByPost(id));
        }
    }
}


