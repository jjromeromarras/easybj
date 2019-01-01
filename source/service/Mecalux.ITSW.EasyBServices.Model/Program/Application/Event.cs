using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class Event: CheckEntity
    {
        #region Fields
        private string internalName;
        private string description;
        private bool isPublic;
        private List<EventProperty> properties;
        #endregion

        #region Constructors

        public Event(Guid id)
            : this()
        {
            Guid = id;
        }

        public Event()
            : base()
        {
            properties = new List<EventProperty>();
            CheckStatus = CheckStatus.New;
            Description =
            InternalName = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string InternalName
        {
            get { return internalName; }
            set { internalName = value; }
        }

        public bool IsPublic
        {
            get { return isPublic; }
            set { isPublic = value; }
        }

        public List<EventProperty> PropertiesInternal
        {
            get => properties;
            set => properties = value;
        }
        #endregion

        #region Methods
        public void AddEventProperty(EventProperty ev)
        {
            ev.ParentSerializableEntity = this;
            properties.Add(ev);
        }
        #endregion
    }
}
