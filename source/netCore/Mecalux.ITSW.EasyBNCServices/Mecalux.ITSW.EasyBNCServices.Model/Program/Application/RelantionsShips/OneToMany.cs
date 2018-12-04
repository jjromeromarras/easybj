using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class OneToMany: Relationship
    {
        #region Fields
        private Guid manyProperty;
        private Guid oneProperty;
        #endregion Fields

        #region Constructors

        public OneToMany(Guid id)
            : this()
        {
            Guid = id;
        }

        public OneToMany()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public Guid ManyProperty
        {
            get => manyProperty; 
            set => manyProperty = value;
        }

        public Guid OneProperty
        {
            get => oneProperty; 
            set => oneProperty = value;
        }

        #endregion Properties
    }
}
