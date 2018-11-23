using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class WorkflowUICommandList: NameEntity, IAvoidSerializedGuid
    {
        #region Properties
        private bool navigationAllowsNullSelection;
        private string navigationNextOptionInternal;
        private string navigationNextPageOptionInternal;
        private WorkflowUICommandNavigationOptions navigationOptionsExitsDialog;
        private string navigationNullSelectionText;
        private string navigationPreviousOptionInternal;
        private string navigationPreviousPageOptionInternal;
        private string selectedValueParameterName;
        private string defaultValueParameterName;
        private string selectOptionExitDialogOptionInternal;
        private string selectOptionDisplayLabelText;
        private string selectOptionDisplayProperty;
        private bool selectOptionExitsDialog;
        private bool selectOptionOnlyList;
        private string selectOptionInternal;
        private CheckEntity parententity;
        #endregion

        #region Constructors

        public WorkflowUICommandList(Guid id)
            : this()
        {
            Guid = id;
        }

        public WorkflowUICommandList(string name)
            : this()
        {
            Name = name;
        }

        public WorkflowUICommandList()
            : base()
        {
            NavigationNullSelectionText =
            SelectOptionDisplayLabelText =
            SelectOptionDisplayProperty = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string DefaultValueParameterName
        {
            get { return defaultValueParameterName; }
            set { defaultValueParameterName = value; }
        }

        public bool NavigationAllowsNullSelection
        {
            get { return navigationAllowsNullSelection; }
            set { navigationAllowsNullSelection=value; }
        }

        public string NavigationNullSelectionText
        {
            get { return navigationNullSelectionText; }
            set { navigationNullSelectionText = value; }
        }

        public WorkflowUICommandNavigationOptions NavigationOptionsExitsDialog
        {
            get { return navigationOptionsExitsDialog; }
            set { navigationOptionsExitsDialog = value; }
        }

        public string SelectedValueParameterName
        {
            get { return selectedValueParameterName; }
            set { selectedValueParameterName = value; }
        }

        public string SelectOptionDisplayLabelText
        {
            get { return selectOptionDisplayLabelText; }
            set { selectOptionDisplayLabelText = value; }
        }

        public string SelectOptionDisplayProperty
        {
            get { return selectOptionDisplayProperty; }
            set { selectOptionDisplayProperty = value; }
        }

        public bool SelectOptionExitsDialog
        {
            get { return selectOptionExitsDialog; }
            set { selectOptionExitsDialog = value; }
        }

        public bool SelectOptionOnlyList
        {
            get { return selectOptionOnlyList; }
            set { selectOptionOnlyList = value; }
        }

        public string NavigationNextOptionInternal
        {
            set { navigationNextOptionInternal = value; }
            get { return navigationNextOptionInternal; }
        }

        public string NavigationNextPageOptionInternal
        {
            set { navigationNextPageOptionInternal = value; }
            get { return navigationNextPageOptionInternal; }
        }

        public string NavigationPreviousPageOptionInternal
        {
            set { navigationPreviousPageOptionInternal = value; }
            get { return navigationPreviousPageOptionInternal; }
        }

        public string SelectOptionExitDialogOptionInternal
        {
            set { selectOptionExitDialogOptionInternal = value; }
            get { return selectOptionExitDialogOptionInternal; }
        }

        public string SelectOptionInternal
        {
            set { selectOptionInternal = value; }
            get { return selectOptionInternal; }
        }

        public string NavigationPreviousOptionInternal
        {
            set { navigationPreviousOptionInternal = value; }
            get { return navigationPreviousOptionInternal; }
        }

        public CheckEntity ParentSerializableEntity
        {
            get => parententity;
            set => parententity = value;
        }

        public Guid ParentSerializableEntityVersionId => parententity != null ? parententity.VersionId : Guid.Empty;

        public string ReferencedName
        {
            get
            {
                string result = string.Empty;
                result += this.ParentSerializableEntity.Name + HelperJsonConverter.Separator + this.Name;
                return result;
            }
        }

        public string SerializationParticle => HelperJsonConverter.DialogListParticle;
        #endregion
    }
}
