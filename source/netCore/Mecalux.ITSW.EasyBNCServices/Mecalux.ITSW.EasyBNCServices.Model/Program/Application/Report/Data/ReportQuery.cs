using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ReportQuery: BaseEntity
    {
        #region Fields

        private string queryExpression;
        private string queryName;
        private string queryOrderBy;
        private string querySelect;
        private bool queryIsReading;
        private QueryTypeDWC queryType;

        #endregion Fields

        #region Constructors

        public ReportQuery(string nameQuery, string selectQuery, string expressionQuery, string orderByQuery, bool isReadingQuery, bool isScalar)
           : this()
        {
            queryName = nameQuery;
            querySelect = selectQuery;
            queryExpression = expressionQuery;
            queryOrderBy = orderByQuery;
            queryIsReading = isReadingQuery;
            IsScalar = isScalar;
            QueryType = queryType;
        }

        public ReportQuery(ReportQuery source)
            : this()
        {
            queryName = source.NameQueryText;
            querySelect = source.SelectQueryText;
            queryExpression = source.ExpressionQueryText;
            queryOrderBy = source.OrderByQueryText;
            queryIsReading = source.IsReadingQuery;
            IsScalar = source.IsScalar;
            QueryType = source.QueryType;
        }

        public ReportQuery()
        {
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

        public bool IsReadingQuery
        {
            get { return queryType == QueryTypeDWC.Reading; }
            set
            {
                if (queryType == QueryTypeDWC.Reading)
                    queryIsReading = true;
                else
                    queryIsReading = false;
            }
        }

        public bool QueryIsReading
        {
            get { return queryIsReading; }
        }

        public string SelectQueryText
        {
            get { return querySelect; }
            set { querySelect = value; }
        }

        public QueryTypeDWC QueryType
        {
            get { return queryType; }
            set { queryType = value; }
        }

        #endregion Properties
    }
}
