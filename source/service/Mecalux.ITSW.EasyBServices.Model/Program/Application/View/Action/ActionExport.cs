using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionExport: Action
    {
        #region Constructors

        public ActionExport(string nameValue)
            : base(nameValue)
        {
        }

        public ActionExport(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionExport()
            : base()
        {
        }

        #endregion Constructors
    }
}
