using Mecalux.ITSW.EasyBService.Model;
using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Mecalux.ITSW.EasyB.Model
{
    public class Action: CheckEntity
    {
        #region Fields
        private string confirmationCode;
        private ConfirmationModes confirmationMode;
        private string confirmationText;
        private Image customImage;
        private string imageName;
        private string quickAccessKey;
        private int sequence;
        private string title;
        private string toolTip;        
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


        public ConfirmationModes ConfirmationMode
        {
            get => confirmationMode;
            set => confirmationMode = value;
        }

        public string ConfirmationText
        {
            get => confirmationText;
            set => confirmationText = value;
        }

        public Image CustomImage
        {
            get { return customImage; }
            set { customImage = value; }
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
        
        public string Title
        {
            get => title;
            set => title = value;
        }

        public string ToolTip
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
