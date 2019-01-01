namespace Mecalux.ITSW.EasyB.Model
{
    public class QueryParameter: NameEntity
    {
        #region Fields
        private object testValue;
        private Stereotype type;
        #endregion Fields

        #region Constructors

        public QueryParameter(string parameterName)
            : this()
        {
            Name = parameterName;
            type = Stereotype.String;
        }

        public QueryParameter(QueryParameter para)
            : this()
        {
            this.Name = para.Name;
            this.testValue = para.testValue;
            this.type = para.type;
        }

        public QueryParameter()
        {
        }

        #endregion Constructors

        #region Properties 

        public Stereotype Type
        {
            get { return type; }
            set { type = value; }
        }

        public object Value
        {
            get { return testValue; }
            set { testValue = value; }
        }


        #endregion Properties

    }
}
