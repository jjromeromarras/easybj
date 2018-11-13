﻿using Mecalux.ITSW.EasyBServices.Base.Enum;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Base
{
    public class ContextConfigExtended: ContextConfig
    {
        #region Fields

        public const string ApplicationModeDeveloper = "DeveloperMode";
        public const string ApplicationModeNormal = "Normal";
        public const int DefaultADServiceTimeoutSeconds = 600;
        public const int DefaultSTSRenewalTimeSeconds = 300;
        private int adServiceTimeoutSeconds;
        private int stsRenewalMarginTimeSeconds;
        private string applicationDictionaryQueryServiceAddress;
        private string applicationMode;
        private string authServerAdressEasySTS;
        private string easyWMSADServiceUri;
        private string easyWMSMetadataServiceAddress;
        private string easyWMSQueryServiceAddress;
        private string easyWMSServiceAddress;
        private string easyWMSWorkflowLogServiceAddress;
        private string queryApplicationDictionaryServiceAdress;
        private string tenantCode;
        private string webApiUri;
        private LicenseLevel licenseLevelInternal;
        private Dictionary<string, LicenseLevel> licenses;
        #endregion
        
        #region Constructors        

        public ContextConfigExtended()
            : base()
        {
            licenses = new System.Collections.Generic.Dictionary<string, LicenseLevel>();
            licenseLevelInternal = LicenseLevel.NONE;            
        }

        #endregion Constructors

        #region Properties

        public int ADServiceTimeoutSeconds
        {
            get => adServiceTimeoutSeconds;
            set => adServiceTimeoutSeconds = value;
        }

        public int StsRenewalMarginTimeSeconds
        {
            get => stsRenewalMarginTimeSeconds;
            set => stsRenewalMarginTimeSeconds = value;
        }

        public string ADServiceUri
        {
            get => easyWMSADServiceUri;
            set => easyWMSADServiceUri = value;
        }

        public string ADServiceVersion { set; get; }

        public string ApplicationDictionaryQueryServiceAddress
        {
            get => applicationDictionaryQueryServiceAddress;
            set => applicationDictionaryQueryServiceAddress = value;
        }
               
        public string AuthServerAdressEasySTS
        {
            get => authServerAdressEasySTS;
            set => authServerAdressEasySTS = value;
        }

        public string EasyWMSMetadataServiceAddress
        {
            get => easyWMSMetadataServiceAddress;
            set => easyWMSMetadataServiceAddress = value;
        }

        public string EasyWMSQueryServiceAddress
        {
            get => easyWMSQueryServiceAddress;
            set => easyWMSQueryServiceAddress = value;
        }

        public string EasyWMSServiceAddress
        {
            get => easyWMSServiceAddress;
            set => easyWMSServiceAddress = value;
        }

        public string EasyWMSWorkflowLogServiceAddress
        {
            get => easyWMSWorkflowLogServiceAddress;
            set => easyWMSWorkflowLogServiceAddress = value;
        }

        /// <summary>
        /// Licencia general. Viene marcada por el valor de la licencia de EasyWMS
        /// </summary>
        public LicenseLevel GlobalLicense { get; internal set; }

        public Dictionary<string, LicenseLevel> Licenses
        {
            set
            {
                if (licenses == null)
                    licenses = new Dictionary<string, LicenseLevel>();
                licenses = value;
            }
            get => licenses; 
        }

        public string QueryApplicationDictionaryServiceAddress
        {
            get => applicationDictionaryQueryServiceAddress;
            set => applicationDictionaryQueryServiceAddress = value;
        }

        public string QueryServiceAPI { get; set; }

        public string TenantCode
        {
            get => tenantCode;
            set => tenantCode = value;
        }

        public string WebApiUri
        {
            get => webApiUri;
            set => webApiUri = value;
        }

        #endregion Properties
    }
}
