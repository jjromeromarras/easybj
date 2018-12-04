using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionViewList: CheckEntity
    {
        #region Fields

        private Action action;
        private ActionViewList internalParentTreeElement;
        private SideAction sideAction;

        #endregion Fields

        #region Constructors

        public ActionViewList(Action actionValue, SideAction sideActionValue)
            : this()
        {

            this.action = actionValue;
            this.sideAction = sideActionValue;
        }

        public ActionViewList(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionViewList()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public Action Action
        {
            get { return action; }
            set { action = value; }
        }

        private SideAction SideActionInternal
        {
            get { return sideAction; }
            set { sideAction = value; }
        }

        #endregion Properties
    }
}
