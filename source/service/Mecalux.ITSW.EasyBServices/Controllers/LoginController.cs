using Mecalux.ITSW.Core.Abstraction;
using Mecalux.ITSW.EasyBServices.Model.Common;
using Mecalux.ITSW.EasyBServices.Model.Data;
using Mecalux.ITSW.EasyBServices.RepositoryManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Mecalux.ITSW.EasyBServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : BaseController
    {
        [HttpPost]
        //[UseSSL]
        [ResponseType(typeof(AuthParameters))]
        [Route("web/setlogin")]
        public AuthParameters SetLogin(HttpRequestMessage request)
        {
            using (LogManager.OpenNestedContext("Login"))
            {
                try
                {
                    string tenant = ConfigurationManager.AppSettings["Tenant"];
                    Login login = JsonConvert.DeserializeObject<Login>(request.Content.ReadAsStringAsync().Result);
                    if (login!=null)
                    {
                        IAuthInfo auth = SecurityHelper.RequestLogin(login.user, login.password, "en", tenant);
                        AuthParameters result = new AuthParameters();
                        result.authinfo = auth;
                        result.token = auth.Token.AccessToken;
                        return result;
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    String messageError = String.Format(CultureInfo.InvariantCulture, "Exception in Login");
                    Log.ErrorException(messageError, ex);
                    throw new QueryException(messageError, ex);
                }
            }
        }

        [HttpGet]
        [Route("web/getlanguages")]
        public Boolean GetLanguages()
        {
            using (LogManager.OpenNestedContext("GetLanguages"))
            {
                try
                {
                    return true;
                }
                catch (Exception ex)
                {
                    String messageError = String.Format(CultureInfo.InvariantCulture, "Exception in GetLanguages");
                    Log.ErrorException(messageError, ex);
                    throw new QueryException(messageError, ex);
                }
            }
        }

    }
}
