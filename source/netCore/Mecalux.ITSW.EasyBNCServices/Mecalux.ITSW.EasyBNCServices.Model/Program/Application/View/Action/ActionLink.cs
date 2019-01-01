using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionLink: Action
    {
        #region Fields

        private Link link;

        #endregion Fields

        #region Constructors
        public ActionLink(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionLink()
            : base()
        {
            this.link = new Link();
            this.link.ParentSerializableEntity = this;
        }

        #endregion Constructors

        #region Properties
        public Link Link
        {
            get { return link; }
            set { link = value; }
        }
        #endregion
    }
}
