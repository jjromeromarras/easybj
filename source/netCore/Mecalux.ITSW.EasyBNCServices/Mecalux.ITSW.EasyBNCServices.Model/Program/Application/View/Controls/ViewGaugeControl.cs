using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewGaugeControl: ViewControl
    {
        #region Fields

        private string entity;
        private GaugeType gaugeType;
        private int maxValue;
        private int minValue;
        private QueryTypeDWC querytypedwc;
        private string sql;
        private string viewgaugeExpressionCode;
        private int warningHighLimit;
        private int warningLowLimit;

        #endregion Fields

        #region Constructors

        public ViewGaugeControl(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewGaugeControl()
            : base(string.Empty, null)
        {
            Sql =
            ViewgaugeExpressionCode = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public GaugeType GaugeType
        {
            get { return gaugeType; }
            set { gaugeType = value; }
        }

        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        public QueryTypeDWC QueryTypeDWC
        {
            get { return querytypedwc; }
            set { querytypedwc = value; }
        }

        public string Sql
        {
            get { return sql; }
            set { sql = value; }
        }

        public string ViewgaugeExpressionCode
        {
            get { return viewgaugeExpressionCode; }
            set {  viewgaugeExpressionCode = value; }
        }

        public int WarningHighLimit
        {
            get { return warningHighLimit; }
            set { warningHighLimit = value; }
        }

        public int WarningLowLimit
        {
            get { return warningLowLimit; }
            set { warningLowLimit = value; }
        }
        #endregion
    }
}
