using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public abstract class CheckEntity: NameEntity
    {
        #region Fields
        private CheckStatus checkStatus;
        private string lockedBy;
        private DateTime? lockedDate;
        private Version version;
        private Guid versionId;

        #endregion

        #region Constructor
        public CheckEntity()
            : base()
        {
            checkStatus = CheckStatus.New;
        }
        #endregion

        #region Properties
        public CheckStatus CheckStatus
        {
            get => checkStatus; 
            set => checkStatus = value;
        }
        [JsonIgnore]
        public string LockedBy
        {
            get => lockedBy;
            set => lockedBy = value;
        }

        [JsonIgnore]
        public DateTime? LockedDate
        {
            get => lockedDate;
            set => lockedDate = value;
        }

        [JsonIgnore]
        public virtual Version Version
        {
            get => version;
            set => version = value;
        }

        [JsonIgnore]
        public Guid VersionId
        {
            get => versionId;
            set => versionId = value;
        }
        #endregion
    }
}
