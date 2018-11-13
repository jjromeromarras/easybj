using Mecalux.ITSW.License;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.License
{
    public static class LicenseProperties
    {
        #region Fields (4)

        private static LicenseGrants currentGrants;
        private static LicenseFeatures features;
        private static bool isActivated;
        private static string licenseTextResult;

        #endregion Fields

        #region Properties (6)

        public static LicenseFeatures ActivatedFeatures
        {
            get { return LicenseProperties.features; }
            set { LicenseProperties.features = value; }
        }

        public static LicenseGrants CurrentGrants
        {
            get
            {
#if !DEBUG
                                if (LicenseProperties.isActivated)
                                {
                                    // En caso de tener permisos de cliente y desarrollador, retornamos los permisos del desarrollador
                                    if (currentGrants.HasFlag(Mecalux.ITSW.EasyBuilder.License.LicenseGrants.Normal))
                                        return LicenseGrants.Normal;
                                    else
                                        return currentGrants;
                                }
                                else
                                    return LicenseGrants.None;
#else
                return LicenseGrants.Any;
#endif
            }
            internal set { currentGrants = value; }
        }

        public static bool IsActivated
        {
            get
            {
#if !DEBUG
                return LicenseProperties.isActivated;
#else
                return true;
#endif
            }
            set { LicenseProperties.isActivated = value; }
        }

        public static string LicenseTextResult
        {
            get
            {
#if !DEBUG
                return LicenseProperties.licenseTextResult;
#else
                return "DEBUG mode";
#endif
            }
            set { LicenseProperties.licenseTextResult = value; }
        }

        public static LicenseStatus Status
        {
            get
            {
#if !DEBUG
                return LicenseManager.ProductLicense.Status;
#else
                return LicenseStatus.Licensed;
#endif
            }
        }

        public static int TrialDaysLeft
        {
            get
            {
#if !DEBUG
                return LicenseManager.ProductLicense.TrialDaysLeft;
#else
                return int.MaxValue;
#endif
            }
        }

        #endregion Properties
    }
}
