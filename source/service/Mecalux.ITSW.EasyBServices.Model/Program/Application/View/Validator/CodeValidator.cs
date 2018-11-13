using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class CodeValidator: Validator
    {
        #region Fields

        private string code;

        #endregion Fields

        #region Constructors

        public CodeValidator(string name, string code)
            : base(name)
        {
            Code = code;
        }

        public CodeValidator(Guid id)
            : this()
        {
            Guid = id;
        }

        public CodeValidator()
            : base()
        {
            Code = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public string Code
        {
            get => code; 
            set => code = value;
        }

        #endregion Properties
    }
}
