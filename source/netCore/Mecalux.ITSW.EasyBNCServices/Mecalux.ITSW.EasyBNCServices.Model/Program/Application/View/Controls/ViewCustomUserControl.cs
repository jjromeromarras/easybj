using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewCustomUserControl: ViewControl
    {
        #region Fields (17)

        private string controlName;
        private string createCommand;
        private string createExpressionCode;
        private string deleteCommand;
        private string deleteExpressionCode;
        private string updateCommand;
        private string updateExpressionCode;

        #endregion Fields

        #region Constructors

        public ViewCustomUserControl(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewCustomUserControl()
            : base(string.Empty, null)
        {
            ControlName =
            CreateExpressionCode =
            DeleteExpressionCode =
            UpdateExpressionCode = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string ControlName
        {
            get { return controlName; }
            set { controlName = value; }
        }

        public string CreateCommand
        {
            get { return createCommand; }
            set { createCommand = value; }
        }

        public string CreateExpressionCode
        {
            get { return createExpressionCode; }
            set { createExpressionCode = value; }
        }

        public string DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; }
        }

        public string UpdateCommand
        {
            get { return updateCommand; }
            set { updateCommand = value; }
        }

        public string DeleteExpressionCode
        {
            get { return deleteExpressionCode; }
            set { deleteExpressionCode = value; }
        }

        public string UpdateExpressionCode
        {
            get { return updateExpressionCode; }
            set { updateExpressionCode = value; }
        }
        #endregion
    }
}
