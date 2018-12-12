using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewGraphControl: ViewControl
    {
        #region Fields

        private string columnTitle;
        private string entity;
        private GraphType graphType;
        private QueryTypeDWC querytypedwc;
        private List<ViewGraphControlSerie> series;
        private bool? showlegend;
        private string sql;
        private string viewGraphExpressionCode;

        #endregion Fields

        #region Constructors

        public ViewGraphControl(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewGraphControl()
            : base(string.Empty, null)
        {
            this.series = new List<ViewGraphControlSerie>();
        }

        #endregion Constructors

        #region Properties

        public string ColumnTitle
        {
            get { return columnTitle; }
            set { columnTitle = value; }
        }

        public string Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public GraphType GraphType
        {
            get { return graphType; }
            set { graphType = value; }
        }

        public QueryTypeDWC QueryTypeDWC
        {
            get { return querytypedwc; }
            set { querytypedwc = value; }
        }

        public IEnumerable<ViewGraphControlSerie> SeriesInternal
        {
            get
            {
                series.Sort((e1, e2) => e1.Column.CompareTo(e2.Column));
                return series;
            }
            set { series = new List<ViewGraphControlSerie>(value); }
        }

        public bool? ShowLegend
        {
            get { return showlegend ?? false; }
            set { showlegend = value; }
        }

        public string Sql
        {
            get { return sql; }
            set { sql = value; }
        }

        public string ViewGraphExpressionCode
        {
            get { return viewGraphExpressionCode; }
            set { viewGraphExpressionCode = value; }
        }
        #endregion

        #region Methods
        public void AddSerie(ViewGraphControlSerie vg)
        {
            vg.ParentSerializableEntity = this;
            series.Add(vg);
        }
        #endregion
    }
}
