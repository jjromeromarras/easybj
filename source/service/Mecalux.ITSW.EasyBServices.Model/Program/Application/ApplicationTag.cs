using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class ApplicationTag: CheckEntity, ICommonEntity
    {
        #region Fields
        private Application entity;
        private DateTime? updateDate;
        private string updatedBy;
        #endregion

        #region Constructors

        public ApplicationTag(string name, string description)
            : this()
        {
            Entity = new Application(name, description);
        }

        public ApplicationTag(Application application)
            : this()
        {
            Entity = application;
        }

        public ApplicationTag()
            : base()
        {
            Version = VersionHelper.InitialVersion;
            this.SetCreateData();
            CreatedBy =
            LockedBy =
            UpdatedBy = string.Empty;
        }

        #endregion Constructors

        #region Methods
        public Application Entity
        {
            get => entity;
            set => entity = value;
        }

        [JsonIgnore]
        public DateTime? UpdateDate
        {
            get => updateDate; 
            set => updateDate = value; 
        }

        

        [JsonIgnore]
        public Guid EntityGuid
        {
            get
            {
                Guid result = Guid.Empty;
                if (Entity != null)
                    result = Entity.Guid;
                return result;
            }
        }

        public override Guid Guid
        {
            get { return new Guid("00000000" + EntityGuid.ToString().Substring(8)); }
            set { base.Guid = value; }
        }
        #endregion
    }
}
