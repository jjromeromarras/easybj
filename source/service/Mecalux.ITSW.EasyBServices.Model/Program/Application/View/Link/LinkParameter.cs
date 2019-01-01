using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class LinkParameter: BaseEntity
    {
        #region Fields

        private string expression;
        private string viewParameter;
        private string viewParameterInternal;

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
        #endregion
    }
}
