using Mecalux.ITSW.EasyBService.Model;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public abstract class MenuBase: NameEntity
    {
        #region Fields
        [JsonIgnore]
        public readonly string MenuParentSeparator = "|#|";
        private int sequence;
        private MenuBase parentMenu;
        private string textInternal;
        #endregion

        #region Properties
        public MenuBase ParentMenu
        {
            get => parentMenu; 
            set
            {
                if (parentMenu != value)
                {
                     parentMenu= value;
                }
            }
        }
      
        public int Sequence
        {
            get => sequence;
            set => sequence = value;
        }
        #endregion

        #region Constructors

        public MenuBase(Guid guid)
            : this()
        {
            this.Guid = guid;
        }

        public MenuBase()            
        {
        }

        #endregion Constructors

        #region Methods

        public string GetIdentifier()
        {
            string result = Text?.Key ?? string.Empty;
            if (this.ParentMenu != null)
                result = string.Format(CultureInfo.CurrentCulture, "{0}{2}{1}", this.ParentMenu.GetIdentifier(), result, MenuParentSeparator);
            return result.ToLower();
        }
        #endregion
    }
}
