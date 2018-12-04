using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class AdJob : CheckEntity
    {
        #region Fields
        private string applicationName;
        private string description;
        private DateTime? endTime;
        private AdJobFrequency frequency;
        private bool isEnabled;
        private bool isSiteJob;
        private DateTime? lastProcessDate;
        private string site;
        private DateTime startDate;
        private DateTime? startTime;
        private string workflowName;
        #endregion

        #region Constructors

        public AdJob(string name, string application, string workflow)
            : this()
        {
            Name = name;
            ApplicationName = application;
            WorkflowName = workflow;
        }

        public AdJob(Guid guid)
            : this()
        {
            base.Guid = guid;
        }

        public AdJob()
            : base()
        {
            
            this.isEnabled = false;
            this.frequency = new AdJobFrequency();
            this.startDate = DateTime.UtcNow.ToLocalTime();
            this.CheckStatus = CheckStatus.New;
            ApplicationName =
            CreatedBy =
            Description =
            Site =
            UpdatedBy =
            WorkflowName = string.Empty;
        }
        #endregion

        #region Properties

        public string ApplicationName
        {
            get => applicationName;
            set => applicationName = value;
        }
     
        public int Days
        {
            get => frequency.Days;
            set => frequency.Days = value;
        }

        public string Description
        {
            get => description; 
            set => description = value;
        }

        public DateTime? EndTime
        {
            get => endTime;
            set => endTime = value;
        }

        public AdJobFrequency Frequency
        {
            get => frequency;
            set => frequency = value;
        }

        public int Hours
        {
            get => frequency.Hours;
            set => frequency.Hours = value;
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set => isEnabled = value;
        }

        public bool IsSiteJob
        {
            get => isSiteJob;
            set => isSiteJob = value;
        }

        public DateTime? LastProcessDate
        {
            get => lastProcessDate; 
            set => lastProcessDate = value;
        }

        public int Minutes
        {
            get => frequency.Minutes; 
            set => frequency.Minutes = value; 
        }

        public int Seconds
        {
            get => frequency.Seconds; 
            set => frequency.Seconds = value; 
        }

        public string Site
        {
            get => site; 
            set => site = value; 
        }

        public DateTime StartDate
        {
            get => startDate; 
            set => startDate = value; 
        }

        public DateTime? StartTime
        {
            get => startTime; 
            set => startTime = value; 
        }
       

        public string WorkflowName
        {
            get => workflowName; 
            set => workflowName = value; 
        }

        #endregion Properties
    }
}
