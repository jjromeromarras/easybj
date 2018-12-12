namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewPanelStep: ViewControl
    {
        #region Fields
        private string command;
        private string confirmationCode;
        private ConfirmationModes confirmationMode;
        private string confirmationText;
        private string entity;
        private string expressionCode;
        #endregion

        #region Constructors

        protected ViewPanelStep(string nameValue, string titleValue, string entityValue)
            : base(nameValue, titleValue)
        {
            ExpressionCode =
            ConfirmationCode = string.Empty;
            this.entity = entityValue;
        }

        protected ViewPanelStep()
            : base(string.Empty, null)
        {
            ExpressionCode =
            ConfirmationCode = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        public string ConfirmationCode
        {
            get { return confirmationCode; }
            set { confirmationCode = value; }
        }

        public ConfirmationModes ConfirmationMode
        {
            get { return confirmationMode; }
            set { confirmationMode = value; }
        }

        public string ConfirmationText
        {
            get { return confirmationText; }
            set { confirmationText = value; }
        }

        public string Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public string ExpressionCode
        {
            get { return expressionCode; }
            set { expressionCode = value; }
        }
        #endregion
    }
}
