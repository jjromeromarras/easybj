using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class WorkflowCommand : WorkflowBasic
    {
        #region Fields

        private string internalCommandName;
        private WorkflowCommandType workflowCommandType;

        #endregion

        #region Constructors       

        public WorkflowCommand(Guid id)
            : this()
        {
            Guid = id;
        }

        /// <summary>
        /// Constructor por defecto.
        /// Por defecto se crea el comando en estado editable.
        /// </summary>
        public WorkflowCommand()
            : base()
        {
            this.WorkflowCommandType = WorkflowCommandType.Bus;
            InternalCommandName = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public string InternalCommandName
        {
            get => internalCommandName;
            set => internalCommandName = value;
        }

        public WorkflowCommandType WorkflowCommandType
        {
            get => workflowCommandType;
            set => workflowCommandType = value;
        }
        #endregion
    }
}
