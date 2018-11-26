using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class EventProperty: NameEntity, IAvoidSerializedGuid
    {
        #region Fields
        private EventPropertyDataType dataType;
        private string description;
        private CheckEntity parententity;
        #endregion

        #region Constructors

        public EventProperty(Guid id)
            : this()
        {
            Guid = id;
        }

        public EventProperty(string name)
            : this()
        {
            Name = name;
        }

        public EventProperty()
            : base()
        {
            dataType = EventPropertyDataType.Boolean;
            Description = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public EventPropertyDataType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

        public string Description
        {
            get { return description; }
            set { description= value; }
        }

        public CheckEntity ParentSerializableEntity
        {
            get => parententity;
            set => parententity = value;
        }

        public Guid ParentSerializableEntityVersionId => parententity != null ? parententity.VersionId : Guid.Empty;

        public string ReferencedName
        {
            get
            {
                return this.Name; 
            }
        }

        public string SerializationParticle => HelperJsonConverter.EventPropertyParticle;
        #endregion
    }
}
