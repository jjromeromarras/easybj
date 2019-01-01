using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class WorkflowUICommand: WorkflowBasic
    {
        #region Fields
        private bool isSelector;
        private List<string> optionsInternal;
        private bool showPromptDefaultValue;
        private WorkflowUICommandEditionKind workflowUICommandEditionKind;
        private WorkflowUICommandPromptType workflowUICommandPromptType;
        private string selectorList;
        private List<WorkflowUICommandFormat> formatsInternal;
        private List<WorkflowUICommandList> listsInternal;
        #endregion

        #region Constructors

        public WorkflowUICommand(Guid id)
            : this()
        {
            Guid = id;
        }

        public WorkflowUICommand()
            : base()
        {
            formatsInternal = new List<WorkflowUICommandFormat>();
            listsInternal = new List<WorkflowUICommandList>();
            optionsInternal = new List<string>();
        }

        #endregion Constructors

        #region Properties
        public bool IsSelector
        {
            get { return isSelector; }
            set { isSelector = value; }
        }

        public string SelectorList
        {
            get { return selectorList; }
            set { selectorList = value; ;
            }
        }

        public bool ShowPromptDefaultValue
        {
            get { return showPromptDefaultValue; }
            set { showPromptDefaultValue= value; }
        }

        public WorkflowUICommandEditionKind WorkflowUICommandEditionKind
        {
            get { return workflowUICommandEditionKind; }
            set { workflowUICommandEditionKind = value; }
        }

        public IEnumerable<WorkflowUICommandFormat> FormatsInternal
        {
            get
            {
                formatsInternal.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return formatsInternal;
            }
            set { formatsInternal = new List<WorkflowUICommandFormat>(value); }
        }

        public IEnumerable<WorkflowUICommandList> ListsInternal
        {
            get
            {
                listsInternal.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return listsInternal;
            }
            set { listsInternal = new List<WorkflowUICommandList>(value); }
        }

        public List<string> OptionsInternal
        {
            get
            {
                optionsInternal.Sort((e1, e2) => e1.CompareTo(e2));
                return optionsInternal;
            }
            set
            {
                optionsInternal = new List<string>(value);
            }
        }

        public WorkflowUICommandPromptType WorkflowUICommandPromptTypeInternal
        {
            get { return workflowUICommandPromptType; }
            set { workflowUICommandPromptType = value; }
        }
        #endregion

        #region Methods
        public void AddWorkflowFormalParameter(WorkflowFormalParameter obj)
        {
            obj.ParentSerializableEntity = this;
            this.FormalParametersInternal.Add(obj);
        }

        public void AddWorkflowUICommandFormat(WorkflowUICommandFormat obj)
        {
            obj.ParentSerializableEntity = this;
            this.formatsInternal.Add(obj);
        }

        public void AddWorkflowUICommandList(WorkflowUICommandList obj)
        {
            obj.ParentSerializableEntity = this;
            this.listsInternal.Add(obj);
        }
        #endregion
    }
}
