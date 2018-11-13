using Mecalux.ITSW.EasyBService.Model;
using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class WorkstationJob: CheckEntity
    {
        #region Fields
        private string description;
        private string imageName;
        private string workflowName;
        private Guid workflowVersionId;
        private Guid title;
        private Guid tooltip;
        #endregion

        #region Constructors

        public WorkstationJob(string nameValue, string descriptionValue, CheckStatus checkStatus)
            : this()
        {
            this.Name = nameValue;
            this.description = descriptionValue;
            this.CheckStatus = checkStatus;
            this.WorkflowName = workflowName;
        }

        public WorkstationJob(Guid id)
            : this()
        {
            Guid = id;
        }

        public WorkstationJob()
            : base()
        {
            this.CheckStatus = CheckStatus.New;
            this.workflowVersionId = Guid.Empty;
            Description =
            ImageName =
            WorkflowName = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public string Description
        {
            get => description; 
            set => description = value;
        }

        public string ImageName
        {
            get => imageName; 
            set => imageName = value;
        }

        public Guid Title
        {
            get => title;
            set => title = value;
        }

        public Guid Tooltip
        {
            get => tooltip; 
            set => tooltip = value;
        }

        /// <summary>
        /// Nombre del WorkflowTagContainer que se referencia por el nombre de Workflow
        /// </summary>
        public string WorkflowName
        {
            get => workflowName; 
            set => workflowName = value;
        }

        /// <summary>
        /// Se almacena el valor de VersionId de un Workflow. Es el Guid del WorkflowTagContainer
        /// </summary>
        public Guid? WorkflowVersionId
        {
            get => workflowVersionId;
            set => workflowVersionId = value ?? Guid.Empty;
        }

        #endregion Properties
    }
}
