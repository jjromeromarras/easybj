using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public abstract class WorkflowBasic: CheckEntity
    {
        #region Fields
        private string description;
        private List<WorkflowFormalParameter> workflowFormalParameters;
        #endregion

        #region Constructors

        public WorkflowBasic(Guid id)
            : this()
        {
            Guid = id;
        }

        protected WorkflowBasic()
            : base()
        {
            workflowFormalParameters = new List<WorkflowFormalParameter>();
            this.Description = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public IEnumerable<WorkflowFormalParameter> FormalParametersInternal
        {
            get
            {
                workflowFormalParameters.Sort((e1, e2) =>
                {
                    int result = e1.Name.CompareTo(e2.Name);
                    if (result == 0 && e1.Attribute != null && e2.Attribute != null)
                        result = e1.Attribute.Name.CompareTo(e2.Attribute.Name);
                    return result;
                });
                return workflowFormalParameters;
            }
            set { workflowFormalParameters = new List<WorkflowFormalParameter>(value); }
        }
        #endregion
    }
}
