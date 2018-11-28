using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class SerializableQuery: BaseEntity
    {
        #region Fields

        private List<QueryParameter> parameters;
        private string queryExpression;
        private string queryName;
        private string queryOrderBy;
        private string querySelect;

        #endregion Fields

        #region Constructors

        public SerializableQuery(SerializableQuery source)
            : this()
        {
            queryName = source.NameQueryText;
            querySelect = source.SelectQueryText;
            queryExpression = source.ExpressionQueryText;
            queryOrderBy = source.OrderByQueryText;
        }

        public SerializableQuery()
        {
            parameters = new List<QueryParameter>();
        }

        #endregion Constructors

        #region Properties

        public string ExpressionQueryText
        {
            get { return queryExpression; }
            set { queryExpression = value; }
        }

        public bool IsScalar { set; get; }

        public string NameQueryText
        {
            get { return queryName; }
            set { queryName = value; }
        }

        public string OrderByQueryText
        {
            get { return queryOrderBy; }
            set { queryOrderBy = value; }
        }

        public List<QueryParameter> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public string SelectQueryText
        {
            get { return querySelect; }
            set { querySelect = value; }
        }

        #endregion Properties
    }
}
