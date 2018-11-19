using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class MenuItem: MenuBase
    {
        #region Fields
        private string expressionCode;
        private string iconName;
        private MenuOrderType menuOrderType;
        private string quickAccessKey;
        private string tooltipInternal;
        private string viewInternal;
        private Image customIcon;
        #endregion Fields

        #region Constructors

        public MenuItem(Guid guid)
            : this()
        {
            base.Guid = guid;
        }

        public MenuItem()
            : base()
        {
            MenuOrder = MenuOrderType.Initial;
            ExpressionCode =
            IconName =
            Name =
            QuickAccessKey = string.Empty;            
        }

        #endregion Constructors

        #region Properties

        public Image CustomIcon
        {
            get => this.customIcon;
            set => customIcon = value;
        }
        
        public string ExpressionCode
        {
            get  => expressionCode;
            set => expressionCode = value;
        }

        [JsonIgnore]
        public string ExpressionCodeReturnValue => "public static IDictionary<string, object>";

        [JsonIgnore]
        public string ExpressionCodeMethodName => "ExpressionCode";

        [JsonIgnore]
        public string ExpressionCodeParams => "(Dictionary<string, object> OrgParameters, IQueryService Query)";

        [JsonIgnore]
        public string ExpressionCodeAdditionalCode => string.Empty;

        [JsonIgnore]
        public string ExpressionCodeHelp => string.Empty;

        [JsonIgnore]
        public string ExpressionCodeExtra => string.Empty;

        [JsonIgnore]
        public string ExpressionCodeExtraForCodeCompiler => string.Empty;

        public string IconName
        {
            get => iconName;
            set => iconName = value;
        }

        public MenuOrderType MenuOrder
        {
            get
            {
                if (Sequence > 5000)
                    return MenuOrderType.Final;
                if (menuOrderType == default(MenuOrderType))
                    menuOrderType = MenuOrderType.Initial;
                return menuOrderType;
            }
            set => menuOrderType = value;
        }

        public string QuickAccessKey
        {
            get =>  quickAccessKey;
            set => quickAccessKey = value;
        }

        public string TooltipInternal
        {
            get => tooltipInternal;
            set => tooltipInternal = value;
        }

        public string ViewInternal
        {
            get => viewInternal;
            set => viewInternal = value;
        }       
        #endregion Properties
    }
}
