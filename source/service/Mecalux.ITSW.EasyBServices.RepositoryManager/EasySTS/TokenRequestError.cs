using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.RepositoryManager.EasySTS
{
    [KnownType(typeof(TokenRequestError))]
    [Serializable]
    public class TokenRequestError
    {
        public string ErrorCode { get; set; }

        public string ErrorDescription { get; set; }

        public TokenRequestError(string errorcode, string errordescription)
        {
            ErrorCode = errorcode;
            ErrorDescription = errordescription;
        }
    }
}
