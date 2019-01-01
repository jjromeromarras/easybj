using System;
using System.Globalization;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public class Lov : CheckEntity, IAvoidSerializedGuid
    {
        #region Fields

        private string displayValue;
        private string valueInternal;
        private CheckEntity parentEntity;
        #endregion Fields

        #region Constructors

        public Lov(string valueValue)
            : this()
        {
            this.valueInternal = valueValue;
        }

        public Lov()
            : base()
        {
            Value = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public ViewFieldLov ParentViewFieldLov
        {
            get { return this.ParentEntity as ViewFieldLov; }
        }

        public virtual CheckEntity ParentEntity
        {
            get { return parentEntity; }
            set { parentEntity = value; }
        }

        public CheckEntity ParentSerializableEntity
        {
            get { return ParentEntity; }
            set { ParentEntity = value; }
        }

        public Guid ParentSerializableEntityVersionId
        {
            get { return ParentEntity.VersionId; }
            set { ParentEntity.VersionId = value; }
        }

        public string ReferencedName
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                Lov lov = this;
                if (this.ParentViewFieldLov != null)
                    builder.AppendFormat(CultureInfo.InvariantCulture, "#{0}|{1}", this.ParentViewFieldLov.ReferencedName, this.Value);
                else
                    builder.Append(this.Value);
                return builder.ToString();
            }
        }

        public string Value
        {
            get { return this.valueInternal; }
            set {  valueInternal = value; }
        }

        public string DisplayValue
        {
            get { return displayValue; }
            set { displayValue = value; }
        }
        public string SerializationParticle { get { return HelperJsonConverter.LovParticle; } }


    #endregion
}
}
