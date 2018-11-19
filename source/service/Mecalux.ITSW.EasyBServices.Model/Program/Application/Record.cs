using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class Record: CheckEntity, ICommonEntity
    {
        #region Fields

        private bool autoUpdateLength;
        private string description;
        private List<FieldRecord> fieldRecords;
        private RecordType recordType;
        private string separator;
        private Guid? overridenVersionId;
        private DateTime? updateDate;

        #endregion Fields

        #region Constructors


        public Record(Guid id)
            : this()
        {
            Guid = id;
        }

        public Record()
            : base()
        {
            this.fieldRecords = new List<FieldRecord>();
            this.CheckStatus = CheckStatus.New;
            this.Version= VersionHelper.InitialVersion;
            this.SetCreateData();
            CreatedBy =
            Description =
            LockedBy =
            Separator =
            UpdatedBy = string.Empty;
        }

        #endregion Constructors

        #region Properties

        [JsonIgnore]
        public DateTime? UpdateDate
        {
            get => updateDate;
            set => updateDate = value;
        }

        public bool AutoUpdateLength
        {
            get => this.autoUpdateLength;
            set => autoUpdateLength = value;
        }

        public string Description
        {
            get => this.description;
            set => this.description = value;
        }
        
        [JsonProperty]
        public Guid? OverriddenVersionId
        {
            get =>overridenVersionId;
            set => overridenVersionId = value; 
        }

        public RecordType RecordType
        {
            get => this.recordType;
            set => this.recordType = value;
        }

        public string Separator
        {
            get => this.separator;
            set => this.separator = value;
        }

        [JsonProperty]
        public IEnumerable<FieldRecord> FieldRecordsInternal
        {
            get
            {
                fieldRecords.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return fieldRecords;
            }
            set { fieldRecords = new List<FieldRecord>(value); }
        }

        #endregion

        #region Methods
        public void AddFieldRecord(FieldRecord obj)
        {
            this.fieldRecords.Add(obj);
        }
        #endregion
    }
}
