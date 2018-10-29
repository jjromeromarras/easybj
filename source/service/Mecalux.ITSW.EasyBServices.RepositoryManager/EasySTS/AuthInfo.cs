using Mecalux.ITSW.Core.Security.Client;
using Mecalux.ITSW.Core.Security.Constants;
using Mecalux.ITSW.EasyBServices.RepositoryManager.EasySTS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.RepositoryManager
{

    public class AuthInfo : IAuthInfo
    {
        #region Properties
        public bool LDAPLogin { get; set; }

        public string UserName { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public TokenRequestError RequestError { get; set; }

        public string CurrentLanguage { get; set; }

        public Guid TenantId { get; set; }

        public string TenantCode { get; set; }

        public IEnumerable<string> Sites { get; set; }

        public string DefaultSite { get; set; }

        public Guid UserId { get; set; }

        public AccessTokenResponse Token { get; set; }
        #endregion
        #region Constructor

        public AuthInfo()
        {
        }

        public AuthInfo(AccessTokenResponse token, TokenClient client, bool isldap)
        {
            LDAPLogin = isldap;
            Token = token;
            if (!string.IsNullOrEmpty(token.IdToken))
            {
                var claims = client.ValidateIdToken(token.IdToken);

                InitializeData(claims);
            }
            RequestError = null;
        }

        public AuthInfo(TokenRequestError error, bool isldap)
        {
            LDAPLogin = isldap;
            TenantCode = string.Empty;
            UserName = string.Empty;
            Roles = new List<string>();
            Sites = new List<string>();
            DefaultSite = string.Empty;
            RequestError = error;
            Token = null;
        }
        #endregion
        #region Private Methods
        private void InitializeData(IEnumerable<System.Security.Claims.Claim> claims)
        {
            UserName = claims.First(c => c.Type == AuthenticationConstants.ClaimTypes.Name).Value;
            string userId = string.Empty;
            if (claims.Any(c => c.Type == AuthenticationConstants.ClaimTypes.UserId))
                userId = claims.First(c => c.Type == AuthenticationConstants.ClaimTypes.UserId).Value;
            Guid parsedUserId = Guid.Empty;
            parsedUserId = ResolveUserId(userId, parsedUserId);
            CurrentLanguage = claims.First(c => c.Type == AuthenticationConstants.ClaimTypes.Language).Value;
            Roles = claims.Where(c => c.Type == AuthenticationConstants.ClaimTypes.Role).Select(c => c.Value);
            TenantCode = claims.First(c => c.Type == AuthenticationConstants.ClaimTypes.TenantCode).Value;
            InitWarehouseInfo(claims);
        }

        private void InitWarehouseInfo(IEnumerable<System.Security.Claims.Claim> claims)
        {
            TenantId = Guid.Parse(claims.First(c => c.Type == AuthenticationConstants.ClaimTypes.TenantId).Value);
            Sites = claims.Where(c => c.Type == AuthenticationConstants.ClaimTypes.Site).Select(c => c.Value);
            if (claims.Where(c => c.Type == AuthenticationConstants.ClaimTypes.DefaultSite).Count() > 0)
                DefaultSite = claims.First(c => c.Type == AuthenticationConstants.ClaimTypes.DefaultSite).Value;
            else
                if (Sites.Count() == 1)
                DefaultSite = Sites.FirstOrDefault();
        }

        private Guid ResolveUserId(string userId, Guid parsedUserId)
        {
            if (Guid.TryParse(userId, out parsedUserId))
            {
                UserId = parsedUserId;
            }
            else
            {
                UserId = Guid.Empty;
            }
            return parsedUserId;
        }
        #endregion
    }
}
