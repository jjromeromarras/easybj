using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
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
    }
}
