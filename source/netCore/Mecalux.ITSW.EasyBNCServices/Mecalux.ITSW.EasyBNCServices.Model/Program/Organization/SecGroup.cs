using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class SecGroup: CheckEntity
    {
        #region Fields
        private List<string> actionsIds;
        private string description;
        private string emailAddress;
        private List<string> rfMenuItemIds;
        private List<string> viewGroupIds;
        #endregion

        #region Constructors

        public SecGroup(Guid value)
                    : this()
        {
            this.Guid = value;
        }

        public SecGroup()
            : base()
        {
            rfMenuItemIds = new List<string>();
            CheckStatus = CheckStatus.New;
            Description =
            EmailAddress = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string Description
        {
            get => description; 
            set => description = value;
        }

        public string EmailAddress
        {
            get  => emailAddress;
            set => emailAddress = value;
        }

        public List<String> RfMenuItemsInternal
        {
            get => rfMenuItemIds;
            set => rfMenuItemIds = value;
        }

        public List<String> ViewGroupsInternal
        {
            get => viewGroupIds;
            set => viewGroupIds = value;
        }

        public List<String> ActionsInternal
        {
            get => actionsIds;
            set => actionsIds = value;
        }
        #endregion
    }
}
