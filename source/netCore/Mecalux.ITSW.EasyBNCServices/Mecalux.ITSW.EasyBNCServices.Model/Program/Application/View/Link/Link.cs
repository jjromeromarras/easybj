using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class Link : NameEntity, IAvoidSerializedGuid
    {
        #region Fields
        private string expressionCode;
        private List<LinkParameter> linkParameters;
        private string targetViewInternal;
        private string targetViewProperty;
        private CheckEntity parentEntity;
        #endregion

        #region Constructors

        public Link(Guid id)
            : this()
        {
            Guid = id;
        }

        public Link()
            : base()
        {
            this.linkParameters = new List<LinkParameter>();
            ExpressionCode = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string ExpressionCode
        {
            get { return expressionCode; }
            set { expressionCode = value; }
        }

        public string TargetViewInternal
        {
            get { return targetViewInternal; }
            set { targetViewInternal = value; }
        }

        public string TargetViewProperty
        {
            get { return targetViewProperty; }
            set { targetViewProperty = value; }
        }

        public List<LinkParameter> LinkParametersInternal
        {
            get { return linkParameters; }
            set { linkParameters = value; }
        }

        public string SerializationParticle
        {
            get { return HelperJsonConverter.LinkParticle; }
        }
              
        public CheckEntity ParentSerializableEntity { get { return this.parentEntity; } set { this.parentEntity = value; } }

        public Guid ParentSerializableEntityVersionId { get { return this.parentEntity.VersionId; } }

        public string ReferencedName
        {
            get
            {
                string result = string.Empty;
                if (this.ParentSerializableEntity is IAvoidSerializedGuid avoidParent)
                    result = avoidParent.ReferencedName ;
                if (targetViewInternal != null)
                    result += HelperJsonConverter.Separator + targetViewInternal;
               
                return result;
            }
        }
        #endregion

        #region Methods
        public void AddLinkParameter(LinkParameter lp)
        {
            lp.ParentSerializableEntity = this.parentEntity;
            linkParameters.Add(lp);
        }
        #endregion
    }
}
