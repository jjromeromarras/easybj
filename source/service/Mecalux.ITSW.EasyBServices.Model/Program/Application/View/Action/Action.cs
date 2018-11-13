using Mecalux.ITSW.EasyBService.Model;
using Mecalux.ITSW.EasyBServices.Model.Enum;
using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class Action: BaseEntity
    {
        #region Fields

        [NonSerialized]

        private const string CodeFooter = "\t}";
        private const string ConfirmationCodeMethodNameConst = "ConfirmationText";
        private const string ConfirmationCodeParametersConst = "({0} View,\n  Dictionary<string, object> ViewParameters,\n  Dictionary<string, object> OrgParameters,\n  IQueryService Query, \n  CultureInfo Culture, \n  ref string ConfirmText, \n  ref ConfirmationMode ConfirmMode)";
        private const string ConfirmationCodeReturnValueConst = "public static bool";
        private const string VisibleConditionMethodNameConst = "ActiveCondition";
        private const string VisibleConditionParametersConst = "({0} View,\n  Dictionary<string, object> ViewParameters,\n  Dictionary<string, object> OrgParameters,\n  IQueryService Query)";
        private const string VisibleConditionReturnValueConst = "public static bool";
        private string confirmationCode;
        private ConfirmationModes confirmationMode;
        private Resource confirmationText;
        //private Image customImage;
        private string imageName;
        private string quickAccessKey;
        private int sequence;
        private Resource title;
        private Resource toolTip;        
        private bool? visible;
        private string visibleCondition;
        private bool visibleMultiRowSelected;
        private bool visibleNoRowSelected;
        private bool visibleOneRowSelected;

        #endregion

        #region Constructors

        protected Action(string nameValue)
            : this()
        {
            this.Name = nameValue;
        }

        protected Action()
            : base()
        {
            VisibleMultiRowSelected =
            VisibleNoRowSelected =
            VisibleOneRowSelected = true;
            visible = true;
            ConfirmationCode =
            ImageName =
            QuickAccessKey =
            VisibleCondition = string.Empty;
        }

        #endregion

        #region Properties

        public string ConfirmationCode
        {
            get  => confirmationCode;
            set => confirmationCode = value;
        }

        [JsonIgnore]
        public string ConfirmationCodeMethodName
        {
            get => ConfirmationCodeMethodNameConst; 
        }

        /*[JsonIgnore]
        public string ConfirmationCodeParameters
        {
            get => string.Format(CultureInfo.InvariantCulture, ConfirmationCodeParametersConst, this.ParentRootView != null ? this.ParentRootView.Name : string.Empty);
        }*/

        [JsonIgnore]
        public string ConfirmationCodeReturnValue
        {
            get => ConfirmationCodeReturnValueConst; 
        }

        public ConfirmationModes ConfirmationMode
        {
            get => confirmationMode;
            set => confirmationMode = value;
        }

        public Resource ConfirmationText
        {
            get => confirmationText;
            set => confirmationText = value;
        }

        /*public Image CustomImage
        {
            get { return customImage; }
            set { SetValue(ref customImage, value); }
        }*/
      
        public override Guid Guid
        {
            get => base.Guid; 
            set => base.Guid = value; 
        }

        public string ImageName
        {
            get => imageName; 
            set => imageName = value; 
        }

        public string QuickAccessKey
        {
            get  => quickAccessKey;
            set => quickAccessKey = value;
        }

        public int Sequence
        {
            get => sequence;
            set => sequence = value;
        }
        
        public Resource Title
        {
            get => title;
            set => title = value;
        }

        public Resource ToolTip
        {
            get => toolTip;
            set => toolTip = value;
        }

        public bool Visible
        {
            get => visible ?? true;
            set => visible = value;
        }

        public string VisibleCondition
        {
            get => visibleCondition;
            set => visibleCondition = value;
        }

        public bool VisibleMultiRowSelected
        {
            get  => visibleMultiRowSelected;
            set => visibleMultiRowSelected = value;
        }

        public bool VisibleNoRowSelected
        {
            get => visibleNoRowSelected;
            set => visibleNoRowSelected = value;
        }

        public bool VisibleOneRowSelected
        {
            get => visibleOneRowSelected;
            set => visibleOneRowSelected = value;
        }

        #endregion
    }
}
