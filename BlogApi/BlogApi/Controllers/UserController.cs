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
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        BlogApiDbContext context = new BlogApiDbContext();
        UserRepository ur = new UserRepository();

        [Route(""),UserAuthentication]
        public IHttpActionResult Get()
        {
            if (ModelState.IsValid)
            {
                return Ok(ur.GetAllData());
            }
            else
            {
                return BadRequest(ModelState);
            }
           
         
        }

        [Route("")]
        public IHttpActionResult Post(User user)
        {
            var u = ur.GetUsername(user.Username);
            if (ModelState.IsValid && u==false )
            {
                
                ur.Insert(user);
                return Created("api/Users/" + user.UserId, user);
            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }

        [Route("{id}"), UserAuthentication]
        public IHttpActionResult Get(int id)
        {
            var user=ur.Get(id);

            if (ModelState.IsValid)
            {
                if (user == null)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                { 
                    return Ok(user); 
                }                          
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [Route("{id}"), UserAuthentication]
        public IHttpActionResult Put([FromUri] int id, [FromBody] User user)
        {
            user.UserId = id;
            if(ModelState.IsValid)
            {
                ur.Update(user);
                return Ok(user);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [Route("{id}"),UserAuthentication]
        public IHttpActionResult Delete(int id)
        {
            if(ModelState.IsValid)
            {
                ur.Delete(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("Login"),UserAuthentication]
        [HttpPost]
        public IHttpActionResult PostLogin( User user)
        {
            var checkedUser = context.Users.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();
            
              //  string Uname = Thread.CurrentPrincipal.Identity.Name;

                if (checkedUser != null)
                {
                   
                    return Ok(checkedUser);
                }
                else
                {
                    return Unauthorized();
                }

        }
        [Route("ExistUser")]
        public IHttpActionResult PostUserExist(User user)
        {
            var u = ur.GetUsername(user.Username);
            return Ok(u);

        }

        [Route("{id}/Post")]
        public IHttpActionResult GetPostByUserID(int id)
        {
            PostRepository pr = new PostRepository();
            return Ok(pr.getAllPostByUser(id));
        }
    }
 }

