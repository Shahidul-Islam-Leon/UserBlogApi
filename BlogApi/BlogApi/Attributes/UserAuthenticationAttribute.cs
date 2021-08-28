using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

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
                string passord = splittedText[1];

                if (true)
                {

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }

    }
}