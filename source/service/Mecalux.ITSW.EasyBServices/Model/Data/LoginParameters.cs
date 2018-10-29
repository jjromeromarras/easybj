using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.Model.Data
{
    [Serializable]
    public class LoginParameters
    {
        public string user { get; set; }
        public string token { get; set; }
    }
}
