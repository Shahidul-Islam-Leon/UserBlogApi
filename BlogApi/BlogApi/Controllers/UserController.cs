using BlogApi.Attributes;
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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        BlogApiDbContext context = new BlogApiDbContext();
        UserRepository ur = new UserRepository();

        [Route(""),UserAuthentication]
        public IHttpActionResult Get()
        {
            return Ok(ur.GetAllData());  
         
        }

        [Route("")]
        public IHttpActionResult Post(User user)
        {
            ur.Insert(user);
            return Created("api/Users/"+user.UserId,user);  
        }

        [Route("{id}"), UserAuthentication]
        public IHttpActionResult Get(int id)
        {
            var user=ur.Get(id);

            if (user==null)
            {
        return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(user);
        }

        [Route("{id}"), UserAuthentication]
        public IHttpActionResult Put([FromUri] int id, [FromBody] User user)
        {
            user.UserId = id;
            ur.Update(user);          
            return Ok(user); 
        }

        [Route("{id}"),UserAuthentication]
        public IHttpActionResult Delete(int id)
        {
            ur.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //[Route("")]
        //public IHttpActionResult PostLogin(User user)
        //{
        //    var checkedUser = context.Users.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
        //    if (ModelState.IsValid)
        //    {

        //        if (checkedUser != null)
        //        {
        //            return Ok(checkedUser);
        //        }
        //        else
        //        {
        //            return Unauthorized();
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}
    }
 }

