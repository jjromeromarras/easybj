using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public abstract class ViewControl: CheckEntity, IAvoidSerializedGuid
    {
        #region Fields
        private int colSpan;
        private int rowSpan;
        private int sequence;
        private string title;
        private string visibilityCondition;
        private CheckEntity parentEntity;
        #endregion

        #region Constructors

        protected ViewControl(string nameValue, string titleValue)
            : base()
        {
            
            this.Name = nameValue;
            this.title = titleValue;
            this.RowSpan = 1;
            this.ColSpan = 1;
            this.Sequence = 1;
            VisibilityCondition = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public int ColSpan
        {
            get { return colSpan; }
            set { colSpan = value; }
        }

        public CheckEntity ParentEntity
        {
            get { return parentEntity; }
            set { parentEntity = value; }
        }

        public string ReferencedName
        {
            get
            {
                StringBuilder builder = new StringBuilder();              
                AddControlToPath(builder);               
                return builder.ToString();
            }
        }

        public virtual int RowSpan
        {
            get { return rowSpan; }
            set { rowSpan = value; }
        }

        public virtual int Sequence
        {
            get { return sequence; }
            set { sequence = value; }
            
        }

        public string SerializationParticle
        {
            get { return HelperJsonConverter.ViewControlParticle; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string VisibilityCondition
        {
            get { return visibilityCondition; }
            set { visibilityCondition = value; }
        }

        public Guid ParentSerializableEntityVersionId
        {
            get { return ParentEntity.VersionId; }
        }

        CheckEntity IAvoidSerializedGuid.ParentSerializableEntity {
            get { return ParentEntity; }
            set { ParentEntity = value; }
        }

        #endregion Properties

        #region Methods
        public void AddControlToPath(StringBuilder builder)
        {
            builder.AppendFormat(CultureInfo.InvariantCulture, "#{0}|{1}", this.GetType().Name, Name);
        }
        #endregion
    }
}
