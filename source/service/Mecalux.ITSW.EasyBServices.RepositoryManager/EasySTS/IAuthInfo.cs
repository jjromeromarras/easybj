using Mecalux.ITSW.Core.Security.Client;
using Mecalux.ITSW.EasyBServices.RepositoryManager.EasySTS;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.RepositoryManager
{

    public interface IAuthInfo
    {
        bool LDAPLogin { get; set; }
        string UserName { get; set; }
        TokenRequestError RequestError { get; set; }
        string CurrentLanguage { get; set; }
        Guid TenantId { get; set; }
        string TenantCode { get; set; }
        IEnumerable<string> Sites { get; set; }
        string DefaultSite { get; set; }
        Guid UserId { get; set; }
        AccessTokenResponse Token { get; set; }
    }

}