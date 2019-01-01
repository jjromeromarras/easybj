using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewParameter: NameEntity
    {
        #region Fields
        private ViewParameterType dataType;
        private bool isRequired;
        private ViewParameterKind parameterKind;
        #endregion
        
        #region Constructors

        public ViewParameter(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewParameter()
            : base()
        {
            this.dataType = ViewParameterType.None;
            this.parameterKind = ViewParameterKind.UserCreated;
        }

        #endregion Constructors

        #region Properties

        public ViewParameterType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }

        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }

        public ViewParameterKind ViewParameterKind
        {
            get { return parameterKind; }
            set { parameterKind = value; }
        }

        #endregion Properties

    }
}
