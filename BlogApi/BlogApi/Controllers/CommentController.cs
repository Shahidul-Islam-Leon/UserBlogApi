using BlogApi.Attributes;
using BlogApi.Models;
using BlogApi.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    [RoutePrefix("api/Comments")]
    public class CommentController : ApiController
    {
        CommentRepository cr = new CommentRepository();
        [Route("") ]
        public IHttpActionResult Get()
        {
            return Ok(cr.GetAllData());
        }
        [Route("") ]
        public IHttpActionResult Post(Comment comment)
        {
            
            cr.Insert(comment);
            return Created("api/Users/" + comment.CommentId, comment);
        }
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var comment = cr.Get(id);

            if (comment == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(comment);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Comment comment)
        {
            comment.CommentId = id;
            cr.Update(comment);
            return Ok(comment);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var comment = cr.Get(id);
            var userId = comment.Post.UserId;
            cr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

