using System;
using System.Reflection;

namespace Mecalux.ITSW.EasyBServices.Base
{
    public static class Context
    {
        #region Fields
        private static ContextConfigExtended contextConfig;
        #endregion

        #region Properties
        public static ContextConfigExtended ContextConfig
        {
            get
            {
                if (contextConfig == null)
                    contextConfig = new ContextConfigExtended();
                return contextConfig;
            }
            set
            {
                contextConfig = value;
                if (contextConfig != null)
                    contextConfig.RebuildContext();
            }
        }

        public static User CurrentUser
        {
            get { return ContextConfig.CurrentUser; }
            set { ContextConfig.CurrentUser = value; }
        }

        public static bool IsActivatedAppsStandardDeveloperMode { get; set; }
        #endregion

        #region Methods
        public static string GetDefaultPath()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(Context));
            var companyAttributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);

            string company = companyAttributes.Length > 0 ? ((AssemblyCompanyAttribute)companyAttributes[0]).Company.Split(' ')[0] : @"Mecalux";

            var productAttributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);

            string product = productAttributes.Length > 0 ? ((AssemblyProductAttribute)productAttributes[0]).Product.Split(' ')[0] : @"EasyBuilder";

            return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), company, product);
        }
        #endregion
    }
}
