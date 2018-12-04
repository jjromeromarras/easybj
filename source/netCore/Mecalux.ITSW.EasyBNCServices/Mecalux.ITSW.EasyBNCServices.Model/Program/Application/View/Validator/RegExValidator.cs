using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class RegExValidator: Validator
    {
        #region Fields

        private string regex;

        #endregion Fields

        #region Constructors

        public RegExValidator(string name, string regex)
            : base(name)
        {
            RegEx = regex;
        }

        public RegExValidator(Guid id)
            : this()
        {
            Guid = id;
        }

        public RegExValidator()
            : base()
        {
            RegEx = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public string RegEx
        {
            get => regex; 
            set => regex = value;
        }

        #endregion Properties
    }
}
