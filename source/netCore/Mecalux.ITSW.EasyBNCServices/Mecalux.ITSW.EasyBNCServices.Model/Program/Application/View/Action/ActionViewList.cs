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
        private CheckEntity parentEntity;
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

        public SideAction SideAction
        {
            get { return sideAction; }
            set { sideAction = value; }
        }

        public CheckEntity ParentEntity
        {
            get { return parentEntity; }
            set { parentEntity = value; }
        }

        public int Sequence
        {
            get
            {
                int i = 1;
                if (action != null)
                    i = action.Sequence;
                return i;
            }
            set
            {
                if (action != null)
                    action.Sequence = value;
            }
        }
        #endregion Properties

       
    }
}
