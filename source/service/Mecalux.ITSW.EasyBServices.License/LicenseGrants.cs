using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.License
{
    [Serializable, Flags]
    public enum LicenseGrants
    {
        None = 0,
        Normal = 10,
        Any = 10,
    }
}
