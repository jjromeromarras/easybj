using Mecalux.ITSW.EasyBServices.RepositoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.Model.Data
{

    
    public class AuthParameters
    {
        public IAuthInfo authinfo { get; set; }
        public string token { get; set; }

    }
}
