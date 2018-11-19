using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class WorkflowAttribute: NameEntity
    {
        #region Fields
        private string description;
        private Guid entityStereotypeInternal;
        private string initialValue;
        private int length;
        private bool persist;
        private Stereotype stereotype;
        #endregion

        #region Constructors

        protected WorkflowAttribute()
            : base()
        {
            persist = true;
            Description =
            InitialValue = string.Empty;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Attribute's Description
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string InitialValue
        {
            get { return initialValue; }
            set { initialValue = value; }
        }

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public bool Persist
        {
            get { return persist; }
            set { persist = value; }
        }

        public Stereotype Stereotype
        {
            get { return stereotype; }
            set
            {
                bool isChanging = stereotype != value;
                stereotype = value;
            }
        }

        public Guid EntityStereotypeInternal
        {
            get => entityStereotypeInternal;
            set => entityStereotypeInternal = value;
        }
        
        #endregion Properties
    }
}
