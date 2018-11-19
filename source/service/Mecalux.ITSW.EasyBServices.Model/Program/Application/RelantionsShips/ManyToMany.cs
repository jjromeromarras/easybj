using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class ManyToMany: Validator
    {
        #region Fields
        private string internalEntity;
        private Guid mInternalProperty;
        private Guid mProperty;
        private Guid nInternalProperty;
        private Guid nProperty;
        #endregion Fields

        #region Constructors

        public ManyToMany(Guid id)
            : this()
        {
            Guid = id;
        }

        public ManyToMany()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public Guid MInternalProperty
        {
            get => mInternalProperty;
            set => mInternalProperty = value;
        }

        public Guid MProperty
        {
            get => mProperty;
            set => mProperty = value;
        }

        public Guid NInternalProperty
        {
            get => nInternalProperty;
            set => nInternalProperty = value;
        }

        public Guid NProperty
        {
            get => nProperty;
            set => nProperty = value;
        }

        public string InternalEntity
        {
            get => internalEntity;
            set => internalEntity = value;
        }

        #endregion Properties
    }
}
