using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ReportData: BaseEntity
    {
        #region Fields

        private List<QueryParameter> parameters;
        private List<ReportQuery> queries;

        #endregion Fields

        #region Constructors

        public ReportData(List<ReportQuery> queriesList, List<QueryParameter> parameterList)
            : this()
        {
            queries = queriesList;
            parameters = parameterList;
        }

        public ReportData(IEnumerable<SerializableQuery> deprecatedData)
            : this()
        {
            if (deprecatedData != null)
                foreach (SerializableQuery oldQuery in deprecatedData)
                {
                    ReportQuery query = new ReportQuery(oldQuery.NameQueryText, oldQuery.SelectQueryText, oldQuery.ExpressionQueryText, oldQuery.OrderByQueryText, true, oldQuery.IsScalar);
                    queries.Add(query);
                    foreach (QueryParameter oldParameter in oldQuery.Parameters)
                    {
                        if (!parameters.Any(p => p.Name == oldParameter.Name))
                        {
                            QueryParameter parameter = new QueryParameter(oldParameter.Name)
                            {
                                Type = oldParameter.Type,
                                Value = oldParameter.Value
                            };
                            parameters.Add(parameter);
                        }
                    }
                }
        }

        public ReportData(ReportData lastQueries)
            : this()
        {
            foreach (var query in lastQueries.queries)
                queries.Add(new ReportQuery(query));
            foreach (var para in lastQueries.parameters)
                parameters.Add(new QueryParameter(para));
        }

        public ReportData()
        {
            parameters = new List<QueryParameter>();
            queries = new List<ReportQuery>();
        }

        #endregion Constructors

        #region Properties

        public List<QueryParameter> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public List<ReportQuery> Queries
        {
            get { return queries; }
            set { queries = value; }
        }

        #endregion Properties
    }
}
