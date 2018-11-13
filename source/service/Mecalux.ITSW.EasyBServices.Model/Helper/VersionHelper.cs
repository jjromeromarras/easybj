using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class VersionHelper
    {
        #region Properties (3)

        public static Version CustomInitialVersion
        {
            get { return new Version(1, 1); }
        }

        public static Version InitialVersion
        {
            get { return new Version(1, 0); }
        }

        public static Version NoneVersion
        {
            get { return new Version(0, 0); }
        }

        #endregion Properties

        #region Methods (2)

        // Public Methods (2) 

        public static int Map(Version version)
        {
            int result = 0;

            if (version == null)
                version = VersionHelper.InitialVersion;

            result = InitialVersion.Major + version.Minor;
            return result;
        }

        public static Version Map(int version)
        {
            Version result = VersionHelper.NoneVersion;
            if (version > 0)
                result = new Version(InitialVersion.Major, version - 1);
            return result;
        }

        #endregion Methods
    }
}
