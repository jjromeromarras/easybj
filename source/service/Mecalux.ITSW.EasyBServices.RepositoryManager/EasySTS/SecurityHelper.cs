using Mecalux.ITSW.Core.Security.Client;
using Mecalux.ITSW.EasyBServices.RepositoryManager.EasySTS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.RepositoryManager
{
    public static class SecurityHelper
    {

        public static TokenClient GetTokenClient()
        {
            string clientSecret = ConfigurationManager.AppSettings["ClientSecretEasySTS"];
            string authServerAdress = ConfigurationManager.AppSettings["AuthServerAdressEasySTS"];
            string applicationId = ConfigurationManager.AppSettings["ApplicationIdEasySTS"];

            return new TokenClient(authServerAdress, applicationId, clientSecret);
        }

        public static IAuthInfo RequestLogin(string username, string pwd, string language, string tenantName)
        {
            try
            {
                TokenClient clt = SecurityHelper.GetTokenClient();
                var tk = clt.RequestToken(username, pwd, tenantName, language);

                IAuthInfo result = new AuthInfo(tk, clt, false);
                return result;
            }
            catch (TokenRequestException e)
            {
                AuthInfo result = null;
                TokenRequestError error = new TokenRequestError(e.ErrorCode, e.ErrorDescription);
                result = new AuthInfo(error, false);
                return result;
            }
        }
    }
}
