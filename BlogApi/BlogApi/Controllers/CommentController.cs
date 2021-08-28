using BlogApi.Models;
using BlogApi.Repositories;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogApi.Controllers
{
    public class CommentController : ApiController
    {
        CommentRepository cr = new CommentRepository();
        public IHttpActionResult Get()
        {
            return Ok(cr.GetAllData());
        }
        public IHttpActionResult Post(Comment comment)
        {
            cr.Insert(comment);
            return Created("api/Users/" + comment.CommentId, comment);
        }

        public IHttpActionResult Get(int id)
        {
            var comment = cr.Get(id);

            if (comment == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(comment);
        }

        public IHttpActionResult Put([FromUri] int id, [FromBody] Comment comment)
        {
            comment.CommentId = id;
            cr.Update(comment);
            return Ok(comment);
        }

        public IHttpActionResult Delete(int id)
        {
            cr.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

