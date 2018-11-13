using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class SecGroupContainer: BaseEntity
    {
        #region Fields
        private List<SecGroup> secGroups;
        #endregion

        #region Constructor
        public SecGroupContainer()
            : base()
        {
            secGroups = new List<SecGroup>();
        }
        #endregion

        #region Properties
        [JsonProperty]
        public IEnumerable<SecGroup> SecGroupsInternal
        {
            get
            {
                secGroups.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return secGroups;
            }
            set => secGroups = new List<SecGroup>(value);
        }
        #endregion

        #region Methods

        public void Add(SecGroup element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "SecGroup can not be null");

                this.secGroups.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "SecGroup exception in add operation: " + ex.Message);
            }


        }

        public void Remove(SecGroup element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "SecGroup can not be null");

                SecGroup obj = this.secGroups.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.secGroups.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "SecGroup exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(SecGroup element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "SecGroup can not be null");

                SecGroup obj = this.secGroups.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "SecGroup doesn't find");
                }
                else
                {
                    this.secGroups.Remove(obj);
                    this.secGroups.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "SecGroup exception in remove operation: " + ex.Message);
            }
        }
        #endregion

    }
}
