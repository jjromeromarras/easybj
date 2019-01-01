using System;
using System.Collections.Generic;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public class View: CheckEntity, IAvoidSerializedGuid
    {
        #region Fields
        private string title;
        private string viewGroup;
        private bool visible;
        private string description;
        private List<ViewParameter> viewParameters;
        private CheckEntity parentEntity;
        #endregion

        #region Constructors
        protected View()
            : base()
        {
            this.viewParameters = new List<ViewParameter>();
            this.visible = true;
            Description = string.Empty;
            this.Version = VersionHelper.CustomInitialVersion;
        }

        #endregion Constructors

        #region Properties

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public CheckEntity ParentEntity
        {
            get { return parentEntity; }
            set { parentEntity = value; }
        }

        
        public Guid ParentSerializableEntityVersionId
        {
            get { return this.VersionId; }
        }

        public string ReferencedName => this.Name;

        public string SerializationParticle
        {
            get { return HelperJsonConverter.ViewParticle; }
        }

        public virtual string Title
        {
            get { return title; }
            set {  title = value; }
        }


        public string ViewGroup
        {
            get { return viewGroup; }
            set { viewGroup = value; }
        }


        /// <summary>
        /// Flag para indicar que esta en estado visible
        /// </summary>
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        protected virtual IEnumerable<ViewParameter> ViewParametersInternal
        {
            get
            {
                viewParameters.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return viewParameters;
            }
            set { viewParameters = new List<ViewParameter>(value); }
        }

        CheckEntity IAvoidSerializedGuid.ParentSerializableEntity
        {
            get { return ParentEntity; }
            set { ParentEntity = value; }
        }

        #endregion Properties

        #region Methods
        public void AddViewParameters(ViewParameter vp)
        {
            this.viewParameters.Add(vp);
        }
        #endregion
    }
}
