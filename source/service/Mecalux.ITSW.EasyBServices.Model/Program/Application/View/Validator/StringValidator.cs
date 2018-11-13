using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class StringValidator: Validator
    {
        #region Fields

        private int lenght;

        #endregion Fields

        #region Constructors

        public StringValidator(string name, int lenght)
            : base(name)
        {
            Lenght = lenght;
        }

        public StringValidator(Guid id)
            : this()
        {
            Guid = id;
        }

        public StringValidator()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public int Lenght
        {
            get => lenght; 
            set => lenght = value;
        }
        
        #endregion Properties
    }
}
