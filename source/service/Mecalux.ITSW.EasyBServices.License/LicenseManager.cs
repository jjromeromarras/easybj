using Mecalux.ITSW.License;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.License
{
    public static class LicenseManager
    {
        #region Fields

        public const short ProductId = 38;
        private readonly static string licensePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Mecalux\EasyBuilder\License");
        private static ProductLicense productLicense;
        private static ProductLicenseManager productLicenseManager;

        #endregion Fields

        #region Events

        public static event EventHandler LicenseChanged;

        #endregion Events

        #region Properties

        public static string LicensePath
        {
            get { return LicenseManager.licensePath; }
        }

        public static ProductLicense ProductLicense
        {
            get { return productLicense; }
            set { productLicense = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Check the license information if we have a valid license either trial or real the application
        /// will continue to work. If there is no valid license and the warehouse was created less than 30 days before
        /// the application will work.
        /// </summary>
        public static void InitializeLicenseManager()
        {
            Nullable<LicenseStatus> previous;
            Nullable<short> previousProductFeatures;
            if (productLicense != null)
            {
                previous = productLicense.Status;
                previousProductFeatures = productLicense.ProductFeatures;
            }
            else
            {
                previous = null;
                previousProductFeatures = null;
            }
            string publicXmlKey = RetrievePublicKey(@"RSAKeys\PublicKey.xml");
            productLicenseManager = new ProductLicenseManager(publicXmlKey);
            if (!Directory.Exists(licensePath))
                CreatePath(licensePath);
            productLicenseManager.SaveMachineKey(Path.Combine(licensePath, "EasyBuilder"));
            productLicense = productLicenseManager.LoadLicense(Path.Combine(licensePath, "EasyBuilder"));
            StringBuilder licenseText = new StringBuilder();
            if (CheckProduct(productLicense))
            {
                licenseText = SwitchLicenseStatus(licenseText);
            }
            else
            {
                LicenseProperties.IsActivated = false;
                licenseText.AppendLine("LIC_WrongProductLicense");
            }

            if (LicenseProperties.ActivatedFeatures.HasFlag(LicenseFeatures.Normal))
                licenseText.Append("LIC_DevelopementFeature");

            if (productLicense.ProductFeatures == 5)
                licenseText.Append("LIC_APPSSTANDARDDEVELOPER");

            LicenseProperties.LicenseTextResult = licenseText.ToString();
            if ((previous.HasValue && previous.Value != productLicense.Status) || (previousProductFeatures.HasValue && previousProductFeatures.Value != productLicense.ProductFeatures))
            {
                EventHandler handler = LicenseChanged;
                if (handler != null)
                    handler(null, EventArgs.Empty);
            }
        }

        // Private Methods (4) 

        /// <summary>
        /// Checks product Id
        /// </summary>
        /// <param name="LicenseProduct">License</param>
        /// <returns>true if the license fits the product ,false otherwise</returns>
        private static bool CheckProduct(ProductLicense LicenseProduct)
        {
            //Check Product ID and Features
            switch (LicenseProduct.ProductFeatures)
            {
                case 5:
                    LicenseProperties.ActivatedFeatures = LicenseFeatures.AppsStandardDeveloper;
                    break;

                default:
                    LicenseProperties.ActivatedFeatures = LicenseFeatures.Normal;
                    break;
            }

            bool result = LicenseProduct.ProductID == ProductId &&
                          LicenseProperties.ActivatedFeatures.HasFlag(LicenseFeatures.Normal);
            if (LicenseProperties.ActivatedFeatures.HasFlag(LicenseFeatures.Normal))
                LicenseProperties.CurrentGrants |= LicenseGrants.Any;
            return result;
        }

        private static void CreatePath(string licensePath)
        {
            string[] pathPart = licensePath.Split(Path.DirectorySeparatorChar);
            string currentPath = pathPart[0] + Path.DirectorySeparatorChar;
            for (int i = 1; i < (pathPart.Length); i++)
            {
                currentPath = Path.Combine(currentPath, pathPart[i]);
                if (!Directory.Exists(currentPath))
                    Directory.CreateDirectory(currentPath);
            }
        }

        private static string RetrievePublicKey(string file)
        {
            string publicXmlKey;
            using (FileStream manifestResourceStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file), FileMode.Open))
            {
                if (manifestResourceStream == null)
                    throw new FileNotFoundException();
                using (StreamReader streamReader = new StreamReader(manifestResourceStream))
                    publicXmlKey = streamReader.ReadToEnd();
            }
            return publicXmlKey;
        }

        private static StringBuilder SwitchLicenseStatus(StringBuilder licenseText)
        {
            switch (productLicense.Status)
            {
                case LicenseStatus.Licensed:
                    licenseText.AppendLine("LIC_Licensed");
                    LicenseProperties.IsActivated = true;
                    break;

                case LicenseStatus.TrialVersion:
                    licenseText.AppendLine("LIC_TrialVersion");
                    licenseText.Append(productLicense.TrialDaysLeft.ToString(CultureInfo.InvariantCulture));
                    LicenseProperties.IsActivated = true;
                    break;

                case LicenseStatus.Expired:
                    licenseText.AppendLine("LIC_Expired");
                    LicenseProperties.IsActivated = false;
                    break;

                case LicenseStatus.InternalError:
                    licenseText.AppendLine("LIC_InternalError");
                    LicenseProperties.IsActivated = false;
                    break;

                case LicenseStatus.MachineHashMismatch:
                    licenseText.AppendLine("LIC_MachineHashMismatch");
                    LicenseProperties.IsActivated = false;
                    break;

                case LicenseStatus.Invalid:
                    licenseText.AppendLine("LIC_defaultActivation");
                    LicenseProperties.IsActivated = false;
                    break;

                default:
                    licenseText.AppendLine("LIC_defaultLicense");
                    LicenseProperties.IsActivated = false;
                    break;
            }

            return licenseText;
        }

        #endregion Methods
    }
}
