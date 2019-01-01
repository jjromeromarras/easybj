using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class Report: CheckEntity
    {
        #region Properties
        private byte[] blobData;
        private Guid blobId;
        private string description;
        private bool isTemplate;
        private Guid overriddenVersionId;
        private string reportLayoutXml;
        private ReportData reportQuery;
        private string reportScripts;
        #endregion

        #region Constructors

        /// <summary>
        /// Class constructor
        /// </summary>
        public Report(CheckStatus startStatus = CheckStatus.New)
            : this()
        {
            blobId = Guid.NewGuid();
            Version = VersionHelper.InitialVersion;
            CheckStatus = startStatus;
            description = string.Empty;
        }

        public Report(Guid id)
            : this()
        {
            Guid = id;
            Version = VersionHelper.InitialVersion;
            Description =
            ReportLayoutXml =
            ReportScripts = string.Empty;
        }

        /// <summary>
        /// Default class constructor
        /// </summary>
        public Report()
            : base()
        {
            Version = VersionHelper.InitialVersion;
            description = string.Empty;
            blobId = Guid.NewGuid();
        }

        #endregion Constructors

        #region Properties

        public byte[] BlobData
        {
            get { return blobData; }
            set
            {
                blobData = value;
            }
        }
        public Guid? OverriddenVersionId
        {
            get
            {
                if (IsOverridden)
                    return this.overriddenVersionId;
                return null;
            }
            set
            {
                this.overriddenVersionId = value ?? Guid.Empty;
            }
        }

        public bool IsOverridden
        {
            get
            {
                if (this.overriddenVersionId != Guid.Empty)
                    return true;
                return false;
            }
        }

        public Guid BlobId
        {
            get { return blobId; }
            set { blobId = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool IsTemplate
        {
            get { return isTemplate; }
            set { isTemplate = value; }
        }

        public string ReportLayoutXml
        {
            get { return reportLayoutXml; }
            set
            {
                reportLayoutXml = value;
            }
        }

        public ReportData ReportQuery
        {
            get
            {
                return reportQuery;
            }
            set { reportQuery = value; }
        }

        public string ReportScripts
        {
            get
            {
                return reportScripts;
            }
            set { reportScripts = value; }
        }


        #endregion Properties       
    }
}
