using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewGridForeignFilter : CheckEntity, IAvoidSerializedGuid
    {
        #region Fields

        private string entity;
        private string property;
        private string title;
        private CheckEntity parentEntity;
        #endregion Fields

        #region Constructors

        public ViewGridForeignFilter(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewGridForeignFilter()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public string Entity
        {
            get { return this.entity; }
            set { this.entity = value; }
        }

        public string Property
        {
            get { return this.property; }
            set { this.property = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public CheckEntity ParentSerializableEntity
        {
            get { return parentEntity; }
            set { parentEntity = value; }
        }

        public Guid ParentSerializableEntityVersionId
        {
            get { return this.parentEntity.VersionId; }
        }

        public string ReferencedName
        {
            get { return this.Name; }
        }

        public string SerializationParticle
        {
            get { return HelperJsonConverter.ViewGridForeignFilterParticle; }
        }
        #endregion
    }
}
