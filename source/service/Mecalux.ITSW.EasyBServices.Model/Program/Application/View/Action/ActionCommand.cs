using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionCommand: Action
    {
        #region Fields
        private string command;
        private string expressionCode;
        private bool issingleexecution;
        #endregion

        #region Constructors

        public ActionCommand(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionCommand()
            : base()
        {
            ExpressionCode = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        public string ExpressionCode
        {
            get { return expressionCode; }
            set { expressionCode = value; }
        }

        public bool IsSingleExecution
        {
            get { return issingleexecution; }
            set { issingleexecution = value; }
        }
        #endregion
    }
}
