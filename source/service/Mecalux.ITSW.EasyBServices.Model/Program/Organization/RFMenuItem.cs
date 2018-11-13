using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class RFMenuItem: MenuBase
    {
        #region Fields
        private string processName;
        #endregion Fields

        #region Constructors

        public RFMenuItem(Guid guid)
            : this()
        {
            base.Guid = guid;
        }

        public RFMenuItem()
            : base()
        {
            groups = new List<SecGroup>();
            processName =
            Name = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string ProcessName
        {
            get => processName; 
            set => processName = value;
        }      
        #endregion
    }
}
