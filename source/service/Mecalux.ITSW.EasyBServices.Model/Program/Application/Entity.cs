using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class Entity: CheckEntity, ICommonEntity
    {
        #region Fields

        private string description;
        private bool fromMetadata;
        private bool isDataWarehouse;
        private string pluralName;
        private string singularName;
        private List<Property> properties;
        private DateTime? updateDate;
        private string tableName;
        
        #endregion Fields

        #region Constructors


        public Entity(Guid id)
            : this()
        {
            Guid = id;
        }

        public Entity()
            : base()
        {
            this.properties = new List<Property>();
            this.CheckStatus = CheckStatus.New;
            this.Version = VersionHelper.InitialVersion;
            this.SetCreateData();
            CreatedBy =
            Description =
            UpdatedBy = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public string Description
        {
            get { return description; }
            set {  description = value; }
        }

        public bool FromMetadata
        {
            get { return fromMetadata; }
            set { fromMetadata = value; }
        }

        public bool IsDataWarehouse
        {
            get { return isDataWarehouse; }
            set { isDataWarehouse = value; }
        }

        public string PluralName
        {
            get { return pluralName; }
            set { pluralName = value; }
        }

        public string SingularName
        {
            get { return singularName; }
            set { singularName = value; }
        }

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public IEnumerable<Property> PropertiesInternal
        {
            get
            {
                properties.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return properties;
            }
            set { properties = new List<Property>(value); }
        }

        public bool IsNew
        {
            get { return CheckStatus == CheckStatus.New; }
        }

        public DateTime? UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }
        #endregion

        #region Methods
        public void AddProperty(Property obj)
        {
            this.properties.Add(obj);
        }
        #endregion
    }
}
