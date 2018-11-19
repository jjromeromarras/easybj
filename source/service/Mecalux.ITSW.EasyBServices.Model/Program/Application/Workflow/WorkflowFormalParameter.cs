using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class WorkflowFormalParameter: NameEntity
    {
        #region Fields

        private WorkflowAttribute attribute;
        private string description;
        private Guid entityStereotypeInternal;
        private int index;
        private bool isEditableParameter;
        private bool isRequiredParameter;
        private WorkflowInOutMode mode;
        private Stereotype stereotype;
        private WorkflowFormalParameterType workflowFormalParameterType;

        #endregion

        #region Constructors    
        public WorkflowFormalParameter(Guid id)
            : this()
        {
            Guid = id;
        }

        public WorkflowFormalParameter()
            : base()
        {
            workflowFormalParameterType = WorkflowFormalParameterType.UserCreated;
            Description = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Guid EntityStereotypeInternal
        {
            get => entityStereotypeInternal;            
            set { entityStereotypeInternal = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public bool IsEditableParameter
        {
            get { return isEditableParameter; }
            set { isEditableParameter = value; }
        }

        public bool IsRequiredParameter
        {
            get { return isRequiredParameter; }
            set {  isRequiredParameter = value; }
        }

        public WorkflowInOutMode Mode
        {
            get { return this.mode; }
            set {  mode = value; }
        }

        public Stereotype Stereotype
        {
            get { return stereotype; }
            set { stereotype = value; }
        }

        public WorkflowFormalParameterType WorkflowFormalParameterType
        {
            get { return workflowFormalParameterType; }
            set { workflowFormalParameterType =  value; }
        }

        public WorkflowAttribute Attribute
        {
            get => attribute;
            set => attribute = value;
        }
        #endregion
    }
}
