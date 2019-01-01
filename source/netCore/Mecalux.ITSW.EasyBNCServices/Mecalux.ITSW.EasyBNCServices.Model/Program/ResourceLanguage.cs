using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class ResourceLanguage: BaseEntity
    {
        #region Fields
        private string countryCode;
        private string data;
        #endregion

        #region Constructors

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="key">The resource Key</param>
        /// <param name="data">The resource data</param>
        public ResourceLanguage(string countryCode, string data)
            : this()
        {
            this.countryCode = String.Intern(countryCode);
            this.data = data;
        }

        /// <summary>
        /// Default class constructor
        /// </summary>
        public ResourceLanguage()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public string CountryCode
        {
            get { return this.countryCode; }
            set { this.countryCode = String.Intern(value); }
        }

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        #endregion

    }
}
