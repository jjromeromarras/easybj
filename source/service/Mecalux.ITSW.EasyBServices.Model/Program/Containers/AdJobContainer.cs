using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class AdJobContainer: BaseEntity
    {
        #region Fields
        private List<AdJob> adJobs;
        #endregion

        #region Constructor
        public AdJobContainer()
            : base()
        {
            adJobs = new List<AdJob>();
        }
        #endregion

        #region Properties
        [JsonProperty]
        public IEnumerable<AdJob> AdJobsInternal
        {
            get
            {
                adJobs.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return adJobs;
            }
            set => adJobs = new List<AdJob>(value);
        }
        #endregion
        
        #region Methods

        public void Add(AdJob element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "AdJob can not be null");

                this.adJobs.Add(element);
                // TODO BASE DE DATOS
            }
            catch(Exception ex)
            {
                throw new ArgumentNullException("element", "AdJob exception in add operation: " + ex.Message);
            }

            
        }

        public void Remove(AdJob element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "AdJob can not be null");

                AdJob job = this.adJobs.Find(p => p.Guid == element.Guid);
                if (job != null)
                {
                    this.adJobs.Remove(job);
                    // TODO BASE DE DATOS
                }
           }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "AdJob exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(AdJob element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "AdJob can not be null");

                AdJob job = this.adJobs.Find(p => p.Guid == element.Guid);
                if (job == null)
                {
                    throw new ArgumentNullException("element", "AdJob doesn't find");                    
                }
                else
                {
                    this.adJobs.Remove(job);
                    this.adJobs.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "AdJob exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
