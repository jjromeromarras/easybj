using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionReport: Action
    {
        #region Fields (2)

        private Report report;

        #endregion Fields

        #region Constructors

        public ActionReport(string nameValue, Report reportValue)
            : base(nameValue)
        {
            this.Report = reportValue;
        }

        public ActionReport(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionReport()
            : base()
        {         
        }

        #endregion Constructors

        #region Properties

        public Report Report
        {
            get { return report; }
            set { report = value; }
        }

        #endregion Properties
    }
}
