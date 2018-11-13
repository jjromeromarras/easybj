using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class ApplicationTagContainer: NameEntity
    {
        #region Fields

        private List<ApplicationTag> applicationTags;

        private Version firstVersionLoaded;

        #endregion Fields

        #region Constructors

        public ApplicationTagContainer(Application application, Version version)
            : this()
        {
            //Si la entidad tiene valor en el campo VersionId crear el contenedor con ese valor
            if (application != null && application.VersionId != Guid.Empty)
                this.Guid = application.VersionId;

            ApplicationTag tag = new ApplicationTag(application);
            tag.Version = version;
            this.Add(tag);
        }

        public ApplicationTagContainer(string name, string description)
            : this(name)
        {
            ApplicationTag tag = new ApplicationTag(NameEntityHelper.CalculateName(this.applicationTags, name), description);
            this.Add(tag);
        }

        public ApplicationTagContainer()
            : base()
        {
            applicationTags = new List<ApplicationTag>();

        }

        private ApplicationTagContainer(string name)
            : this()
        {
            Name = name;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds an ApplicationTagContainer
        /// </summary>
        /// <param name="element">ApplicationTag to add</param>
        /// <exception cref="ArgumentNullException">Param ApplicationTag is null</exception>
        /// <exception cref="ArgumentException">ApplicationTag couldn't be added</exception>
        public void Add(ApplicationTag element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Application can not be null");

                this.applicationTags.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Application exception in add operation: " + ex.Message);
            }
        }

        public void Remove(ApplicationTag element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Application can not be null");

                ApplicationTag menu = this.applicationTags.Find(p => p.Guid == element.Guid);
                if (menu != null)
                {
                    this.applicationTags.Remove(menu);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Application exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
