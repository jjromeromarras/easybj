using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class RecordList: CheckEntity, ICommonEntity
    {
        #region Fields
        private string description;
        private int files;
        private string record;
        private DateTime? updateDate;
        #endregion Fields

        #region Constructors
        public RecordList(Guid id)
            : this()
        {
            Guid = id;
        }

        public RecordList()
            : base()
        {
            Version = VersionHelper.InitialVersion;
            files = 1;
            CheckStatus = CheckStatus.New;
            CreatedBy =
            LockedBy =
            UpdatedBy = string.Empty;
            this.SetCreateData();
        }

        #endregion Constructors

        #region Properties

        public string Description
        {
            get => this.description; 
            set => this.description = value;
        }

        public int Files
        {
            get => this.files; 
            set => this.files = value;
        }

        public string Record
        {
            get => this.record; 
            set => this.record = value;
        }


        public DateTime? UpdateDate
        {
            set => updateDate = value; 
            get => updateDate; 
        }
        
        #endregion Properties
    }
}
