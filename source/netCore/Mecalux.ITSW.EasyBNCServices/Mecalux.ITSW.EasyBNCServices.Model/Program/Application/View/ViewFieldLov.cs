using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewFieldLov: CheckEntity, IAvoidSerializedGuid
    {
        #region Fields
        private string dependantProperty;
        private string dependantViewFieldLov;
        private string displayProperty;
        private string entity;
        private Link inLineLink;
        private List<Lov> lovs;
        private OrderLovType orderLovType;
        private int rowLimit;
        private List<Guid> showProperties;
        private string sqlOrderBy;
        private string sqlWhere;
        private string valueProperty;
        private CheckEntity parentEntity;
        #endregion

        #region Constructors


        public ViewFieldLov()
            : base()
        {
            this.lovs = new List<Lov>();
            this.showProperties = new List<Guid>();
            SqlOrderBy =
            SqlWhere = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public string DependantProperty
        {
            get { return dependantProperty; }
            set { dependantProperty = value; }
        }

        public string DependantViewFieldLOV
        {
            get { return dependantViewFieldLov; }
            set { dependantViewFieldLov = value; }
        }

        public string DisplayProperty
        {
            get { return displayProperty; }
            set { displayProperty = value; }
        }

        public Link InLineLink
        {
            get { return inLineLink; }
            set { inLineLink = value; }
        }

        public OrderLovType OrderLovType
        {
            get { return orderLovType; }
            set { orderLovType = value; }
        }

        public string EntityInternal
        {
            get { return entity; }
            set { entity = value; }
        }

        public int RowLimit
        {
            get { return rowLimit; }
            set { rowLimit = value; }
        }

        public string SqlOrderBy
        {
            get { return sqlOrderBy; }
            set { sqlOrderBy = value; }
        }

        public string SqlWhere
        {
            get { return sqlWhere; }
            set { sqlWhere = value; }
        }

        public string ValueProperty
        {
            get { return valueProperty; }
            set { valueProperty = value; }
        }

        public IEnumerable<Lov> LovsInternal
        {
            get
            {
                lovs.Sort((e1, e2) => e1.Value.CompareTo(e2.Value));
                return lovs;
            }
            set { lovs = new List<Lov>(value); }
        }

        public List<Guid> ShowPropertiesInternal
        {
            get
            {
                return showProperties;
            }
            set { showProperties = new List<Guid>(value); }
        }

        public CheckEntity ParentSerializableEntity
        {
            get { return this.parentEntity; }
            set { this.parentEntity = value; }
        }
        public Guid ParentSerializableEntityVersionId
        {
            get
            {
                return this.parentEntity.VersionId;
            }
        }

        public string ReferencedName
        {
            get { return (parentEntity as IAvoidSerializedGuid).ReferencedName; }
        }

        public string SerializationParticle
        {
            get { return HelperJsonConverter.ViewFieldLovParticle; }
        }

        CheckEntity IAvoidSerializedGuid.ParentSerializableEntity {
            get { return parentEntity; }
            set { parentEntity = value; }
        }

        #endregion

        #region Methods
        public void AddLov(Lov lov)
        {
            lov.ParentEntity = this.parentEntity;
            lovs.Add(lov);
        }

        public void CreateInLineLink()
        {
            this.inLineLink = new Link();
            this.inLineLink.ParentSerializableEntity = this.parentEntity;
        }
        #endregion
    }
}
