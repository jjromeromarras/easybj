using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class WorkflowQueryCommand: WorkflowBasic
    {
        #region Fields
        private string expression;        
        private bool isScalar;
        private bool isTemplate;
        private string parentQueryInternal;
        private WorkflowQueryCommandType queryType;
        #endregion

        #region Constructors

        public WorkflowQueryCommand(Guid id)
            : this()
        {
            Guid = id;
        }

        public WorkflowQueryCommand()
            : base()
        {
            Expression = string.Empty;
            QueryType = WorkflowQueryCommandType.Reading;
        }

        #endregion Constructors

        #region Properties
        public string Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public bool IsScalarInternal
        {
            get { return isScalar; }
            set { isScalar = value; }
        }

        public string ParentQueryInternal
        {
            get { return parentQueryInternal; }
            set { parentQueryInternal = value; }
        }

        public WorkflowQueryCommandType QueryType
        {
            get { return queryType; }
            set { queryType = value; }
        }
        #endregion
    }
}
