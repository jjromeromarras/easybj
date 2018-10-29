using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;


namespace Mecalux.ITSW.EasyBServices
{
    public sealed class UseSSLAttribute : AuthorizationFilterAttribute
    {
        

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                String messageError = String.Format(CultureInfo.InvariantCulture, "Error in authorization: SSL is required");
                SecurityException ex = new SecurityException(messageError);
                throw new QueryException(messageError, new SecurityException(messageError));
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}
