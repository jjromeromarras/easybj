using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionGroup: Action
    {
        #region Fields

        private List<Action> actions;

        #endregion Fields

        #region Constructors

        public ActionGroup(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionGroup(string nameValue)
            : base(nameValue)
        {         
            this.actions = new List<Action>();         
        }

        public ActionGroup()
            : base()
        {         
            this.actions = new List<Action>();         
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<Action> ActionsInternal
        {
            get
            {
                actions.Sort((e1, e2) =>
                {
                    int result = e1.Sequence.CompareTo(e2.Sequence);
                    if (result == 0 && !string.IsNullOrEmpty(e1.Name))
                        result = e1.Name.CompareTo(e2.Name);
                    return result;
                });
                return actions;
            }
            set { actions = new List<Action>(value); }
        }
        #endregion

        #region Methods
        public void AddAction(Action obj)
        {
            this.actions.Add(obj);
        }
        #endregion
    }
}
