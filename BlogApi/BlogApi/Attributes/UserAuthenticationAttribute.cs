using BlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BlogApi.Repository;
using System.Threading;
using System.Security.Principal;
using BlogApi.Repositories;

namespace BlogApi.Attributes
{

    public class UserAuthenticationAttribute:AuthorizationFilterAttribute
    {
    

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodeString = actionContext.Request.Headers.Authorization.Parameter;
                string decotedString = Encoding.UTF8.GetString(Convert.FromBase64String(encodeString));
                string[] splittedText = decotedString.Split(new char[] { ':' });
                string username = splittedText[0];
                string password = splittedText[1];

               // UserRepository ur = new UserRepository();

              //  ur.GetUsernamePass(username, password);
            

                if (UserRepository.Login(username,password))
                {

                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    
                }
                else
                {

                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }


                //if (UserRepository.Login(username,password))
                //{

                //    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);

                //}
                //else
                //{

                //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                //}
            }
        }

    }
}