using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewDetailPanel: ViewFieldContainerControl
    {
        #region Fields
        private string createCommand;
        private string createExpressionCode;
        private string deleteCommand;
        private string deleteExpressionCode;
        private string detailEntity;
        private string sqlOrderBy;
        private string sqlWhere;
        private string updateCommand;
        private string updateExpressionCode;
        #endregion

        #region Constructors
        
        public ViewDetailPanel(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewDetailPanel()
            : base(string.Empty, null)
        {
            CreateExpressionCode =
            DeleteExpressionCode =
            SqlOrderBy =
            SqlWhere =
            UpdateExpressionCode = string.Empty;
        }

        #endregion Constructors

        #region Properties

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

        public string DeleteExpressionCode
        {
            get { return deleteExpressionCode; }
            set { deleteExpressionCode = value; }
        }

        public string DetailEntity
        {
            get { return detailEntity; }
            set { detailEntity = value; }
        }

        public string SqlOrderBy
        {
            get { return sqlOrderBy; }
            set { sqlOrderBy = value; }
        }
        public string SqlWhere
        {
            get { return sqlWhere; }
            set { sqlWhere = value; }
        }

        public string UpdateCommand
        {
            get { return updateCommand; }
            set { updateCommand = value; }
        }

        public string UpdateExpressionCode
        {
            get { return updateExpressionCode; }
            set { updateExpressionCode = value; }
        }

        #endregion Properties
    }
}
