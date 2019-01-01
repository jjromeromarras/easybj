using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class WorkstationJobContainer: BaseEntity
    {
        #region Fields
        private List<WorkstationJob> workstationJobs;
        #endregion

        #region Constructors

        /// <summary>
        /// Default class constructor
        /// </summary>
        public WorkstationJobContainer()
            : base()
        {
            workstationJobs = new List<WorkstationJob>();
            Guid = new Guid(GuidPrefix.WorkstationJobContainer + Guid.ToString().Substring(8));
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<WorkstationJob> WorkstationJobsInternal
        {
            get
            {
                workstationJobs.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return workstationJobs;
            }
            set { workstationJobs = new List<WorkstationJob>(value); }
        }
        #endregion

        #region Methods

        public void Add(WorkstationJob element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkstationJob can not be null");

                this.workstationJobs.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "WorkstationJob exception in add operation: " + ex.Message);
            }


        }

        public void Remove(WorkstationJob element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkstationJob can not be null");

                WorkstationJob obj = this.workstationJobs.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.workstationJobs.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "WorkstationJob exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(WorkstationJob element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkstationJob can not be null");

                WorkstationJob obj = this.workstationJobs.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "WorkstationJob doesn't find");
                }
                else
                {
                    this.workstationJobs.Remove(obj);
                    this.workstationJobs.Add(element);
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
