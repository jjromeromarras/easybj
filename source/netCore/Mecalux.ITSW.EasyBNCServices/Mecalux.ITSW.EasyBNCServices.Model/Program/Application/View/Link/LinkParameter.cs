using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class LinkParameter: BaseEntity, IAvoidSerializedGuid
    {
        #region Fields

        private string expression;
        private string viewParameterInternal;
        private CheckEntity parentEntity;
        #endregion Fields

        #region Constructors

        public LinkParameter(Guid id)
            : this()
        {
            Guid = id;
        }

        public LinkParameter()
            : base()
        {
            Expression = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public string ViewParameterInternal
        {
            get { return viewParameterInternal; }
            set { viewParameterInternal = value; }
        }

        public CheckEntity ParentSerializableEntity
        {
            get { return parentEntity; }
            set { parentEntity = value; }
        }

        public Guid ParentSerializableEntityVersionId
        {
            get { return parentEntity.VersionId; }
        }

        public string ReferencedName
        {
            get
            {
                string result = string.Empty;
                if (this.parentEntity is IAvoidSerializedGuid avoidParent)
                    result = avoidParent.ReferencedName + HelperJsonConverter.Separator;
                if (this.parentEntity != null)
                    result += this.parentEntity.Name;
                return result;
            }
        }

        public string SerializationParticle
        {
            get { return HelperJsonConverter.LinkParameterParticle; }
        }
        #endregion
    }
}
