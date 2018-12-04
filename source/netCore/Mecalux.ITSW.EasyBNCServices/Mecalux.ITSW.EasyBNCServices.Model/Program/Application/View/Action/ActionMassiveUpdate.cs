using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionMassiveUpdate: Action
    {
        #region Fields

        private WorkflowCommand massiveUpdateCommand;

        #endregion

        #region Constructors       

        public ActionMassiveUpdate(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionMassiveUpdate()
            : base()
        {
            massiveUpdateCommand = new WorkflowCommand();
        }

        #endregion Constructors

        #region Properties

        public WorkflowCommand MassiveUpdateCommand
        {
            get { return massiveUpdateCommand; }
            set {  massiveUpdateCommand = value; }
        }

        #endregion Properties
    }
}
