using System;
using System.Collections.Generic;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewField: ViewControl
    {
        #region Fields
        public const string CellStyleDefaultReturnValue = "\n\nreturn GridCellStyle.None;";
        private bool allowAdvancedSearch;
        private bool allowEdit;
        private bool allowMassiveUpdate;
        private bool allowMultiEdit;
        private bool allowSearch;
        private string cellStyle;
        private string defaultValueCode;
        private Link drillDownLink;
        private string editableCondition;
        private ViewFieldImageMode imageFalseMode;
        private string imageNameFalse;
        private string imageNameTrue;
        private ViewFieldImageMode imageTrueMode;
        private bool isRequired;
        private bool isVisible;
        private bool isVisibleOnCreation;
        private ViewFieldLov lov;
        private string property;
        private bool reEvaluateVisibilityOnChange;
        private string requiredCondition;
        private bool searchResource;
        private bool showInCollapsedGrid;
        private bool showInExpandedGrid;
        private string tooltip;
        private bool useValueExpressionCode;
        private string validator;
        private string validatorCode;
        private string validatorText;
        private string valueExpressionCode;
        private string viewAdvancedSearch;
        private string viewAdvancedSearchCode;
        private ViewFieldType viewFieldType;

        #endregion Fields

        #region Constructors

        public ViewField()
            : base(string.Empty, null)
        {
            InitializeClass();
        }

        #endregion Constructors

        #region Properties

        public bool AllowAdvancedSearch
        {
            get { return allowAdvancedSearch; }
            set { allowAdvancedSearch = value; }
        }

        public bool AllowEdit
        {
            get { return this.allowEdit; }
            set { allowEdit = value; }
        }

        public bool AllowMassiveUpdate
        {
            get { return allowMassiveUpdate; }
            set { allowMassiveUpdate = value; }
        }

        public bool AllowMultiEdit
        {
            get { return allowMultiEdit; }
            set { allowMultiEdit = value; }
        }

        public bool AllowSearch
        {
            get { return allowSearch; }
            set { allowSearch = value; }
        }

        public string CellStyle
        {
            get { return cellStyle; }
            set
            {
                if (string.IsNullOrEmpty(value?.Trim()))
                    cellStyle = CellStyleDefaultReturnValue;
                else
                    cellStyle = value;
            }
        }

        public string DefaultValueCode
        {
            get { return defaultValueCode; }
            set { defaultValueCode = value; }
        }

        public Link DrillDownLink
        {
            get { return drillDownLink; }
            set { drillDownLink = value; }
        }

        public string EditableCondition
        {
            get { return editableCondition; }
            set { editableCondition = value; }
        }

        public ViewFieldImageMode ImageFalseMode
        {
            get { return imageFalseMode; }
            set { imageFalseMode = value; }
        }

        public string ImageNameFalse
        {
            get { return imageNameFalse; }
            set { imageNameFalse = value; }
        }

        public string ImageNameTrue
        {
            get { return imageNameTrue; }
            set { imageNameTrue = value; }
        }

        public ViewFieldImageMode ImageTrueMode
        {
            get { return imageTrueMode; }
            set { imageTrueMode = value; }
        }

        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public bool IsVisibleOnCreation
        {
            get { return isVisibleOnCreation; }
            set { isVisibleOnCreation = value; }
        }

        public ViewFieldLov Lov
        {
            get { return lov; }
            set { lov = value; }
        }

        public string Property
        {
            get { return property; }
            set { property = value; }
        }

        public bool ReEvaluateVisibilityOnChange
        {
            get { return reEvaluateVisibilityOnChange; }
            set { reEvaluateVisibilityOnChange = value; }
        }

        public string RequiredCondition
        {
            get { return requiredCondition; }
            set { requiredCondition = value; }
        }

        public bool SearchResource
        {
            get { return searchResource; }
            set { searchResource = value; }
        }

        public bool ShowInCollapsedGrid
        {
            get { return showInCollapsedGrid; }
            set { showInCollapsedGrid = value; }
        }

        public bool ShowInExpandedGrid
        {
            get { return showInExpandedGrid; }
            set { showInExpandedGrid = value; }
        }

        public string Tooltip
        {
            get { return tooltip; }
            set { tooltip = value; }
        }

        public bool UseValueExpressionCode
        {
            get { return useValueExpressionCode; }
            set { useValueExpressionCode = value; }
        }

        public string Validator
        {
            get { return validator; }
            set { validator = value; }
        }

        public string ValidatorCode
        {
            get { return validatorCode; }
            set { validatorCode = value; }
        }

        public string ValidatorText
        {
            get { return validatorText; }
            set { validatorText = value; }
        }

        public string ValueExpressionCode
        {
            get { return valueExpressionCode; }
            set { valueExpressionCode = value; }
        }

        public string ViewAdvancedSearch
        {
            get { return viewAdvancedSearch; }
            set { viewAdvancedSearch = value; }
        }

        public string ViewAdvancedSearchCode
        {
            get { return viewAdvancedSearchCode; }
            set { viewAdvancedSearchCode = value; }
        }

        public ViewFieldType ViewFieldType
        {
            get { return viewFieldType; }
            set { viewFieldType = value; }
        }


        #endregion Properties

        #region Methods
        private void InitializeClass()
        {
            this.ImageTrueMode = ViewFieldImageMode.Default;
            this.ImageFalseMode = ViewFieldImageMode.Default;
            this.viewFieldType = ViewFieldType.None;
            this.isVisible = true;
            this.Sequence = 0;
            this.allowEdit = true;
            this.isVisibleOnCreation = true;
            CellStyle =
            DefaultValueCode =
            EditableCondition =
            ImageNameFalse =
            ImageNameTrue =
            RequiredCondition =
            ValidatorCode =
            ValueExpressionCode =
            ViewAdvancedSearchCode = string.Empty;
        }

        public void CreateViewFielLov()
        {
            this.lov = new ViewFieldLov();
            this.lov.ParentSerializableEntity = this;
        }

        public void AddViewFielLov(ViewFieldLov lov)
        {
            this.lov = lov;
            this.lov.ParentSerializableEntity = this;
        }

        public void CreateDrillDownLink()
        {
            this.drillDownLink = new Link();
            this.drillDownLink.ParentSerializableEntity = this;
        }

        public void AddDrillDownLink(Link link)
        {
            this.drillDownLink = link;
            this.drillDownLink.ParentSerializableEntity = this;
        }
        #endregion
    }
}
