using Mecalux.ITSW.EasyB.Model;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Mecalux.ITSW.EasyBService.Model
{
    [JsonObject]
    public class Resource: CheckEntity
    {
        #region Properties
        private string key;        
        private List<ResourceLanguage> resourceTranslations;
        #endregion

        #region Constructors

        /// <summary>
        /// Class constructor, creates a resource with the indicated key and data for all the supported languages
        /// </summary>
        /// <param name="resourceKey">The resource key</param>
        /// <param name="resourceData">The resource data</param>
        /// <param name="startStatus">The resource start status</param>
        public Resource(string resourceKey, string resourceData, ICollection<string> countryCodes, CheckStatus startStatus = CheckStatus.New)
            : this()
        {
            this.Key = resourceKey;
            this.CheckStatus = startStatus;
            this.VersionId = this.Guid;
            if (countryCodes != null)
            {
                foreach (string countryCode in countryCodes)
                {
                    ResourceLanguage resourceLanguage = new ResourceLanguage(countryCode, resourceData);
                }
            }
        }

        public Resource(Guid id)
            : this()
        {
            this.Guid = id;
            this.VersionId = this.Guid;
        }

        /// <summary>
        /// Default class constructor
        /// </summary>
        public Resource()
            : base()
        {
            resourceTranslations = new List<ResourceLanguage>();
            CreateDate = DateTime.UtcNow.ToLocalTime();
            CheckStatus = CheckStatus.New;
            Version = VersionHelper.InitialVersion;
            CreatedBy =
            LockedBy =
            Name =
            UpdatedBy = string.Empty;
        }

        #endregion Constructors

        #region Properties 
        public virtual string Key
        {
            get => key;
            set => key = value;            
        }

        public IEnumerable<ResourceLanguage> ResourceLanguagesInternal
        {
            get
            {
                resourceTranslations.Sort((e1, e2) => e1.CountryCode.CompareTo(e2.CountryCode));
                return resourceTranslations;
            }
            set { resourceTranslations = new List<ResourceLanguage>(value); }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Adds a ResourceLanguage
        /// </summary>
        /// <param name="element">ResourceLanguage to add</param>
        /// <exception cref="ArgumentNullException">Param ResourceLanguage is null</exception>
        /// <exception cref="ArgumentException">ResourceLanguage couldn't be added</exception>
        public void Add(ResourceLanguage element)
        {
            this.Add(element, true);
        }


        /// <summary>
        /// Adds a ResourceLanguage
        /// </summary>
        /// <param name="element">ResourceLanguage to add</param>
        /// <exception cref="ArgumentNullException">Param ResourceLanguage is null</exception>
        /// <exception cref="ArgumentException">ResourceLanguage couldn't be added</exception>
        public void Add(ResourceLanguage element, bool checkDuplicates)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if (checkDuplicates)
            {
                if(this.resourceTranslations.Any(p=>p.CountryCode==element.CountryCode))
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "The element [{0}] already exists in the collection", element));
            }
            this.resourceTranslations.Add(element);
        }

        /// <summary>
        /// Removes a ResourceLanguage
        /// </summary>
        /// <param name="element">ResourceLanguage to remove</param>
        /// <exception cref="ArgumentNullException">ResourceLanguage is null</exception>
        /// <exception cref="ArgumentException">ResourceLanguage couldn't be removed</exception>
        public void Remove(ResourceLanguage element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));
            this.resourceTranslations.Remove(element);
        }
        #endregion
    }
}
