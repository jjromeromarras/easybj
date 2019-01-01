using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class Application: SignedEntity
    {
        #region Fields
        private string imagesFolder;
        private string description;
        private MenuItemContainer menuItemContainer;
        private RFMenuItemContainer rfMenuItemContainer;
        private SecGroupContainer secGroupContainer;
        private AdJobContainer adJobContainer;
        private ViewGroupContainer viewgroupContainer;
        private GlobalSearchContainer globalsearchcontainer;
        private WorkstationJobContainer workstationJobContainer;
        private WorkflowCommandContainer workflowCommandContainer;
        private ValidatorContainer validatorContainer;
        private EntityContainer entityContainer;
        private List<Guid> dependingApplications;
        private List<Guid> dependingApplicationsIndirect;
        private WorkflowUICommandContainer workflowUICommandContainer;
        private WorkflowQueryCommandContainer workflowQueryCommandContainer;
        private Nullable<DateTime> activationDate;
        private Nullable<DateTime> compilationDate;
        private DateTime updateDate;
        private Contact contact;
        private Company company;
        private RecordContainer recordContainer;
        private FieldTypeContainer fieldTypeContainer;
        private RecordListContainer recordListContainer;
        private EventContainer eventContainer;
        #endregion

        #region Constructors

        public Application(string name, string description, Guid id, CheckStatus status = CheckStatus.New)
            : this(name, description, status)
        {
            Guid = id;
        }

        public Application(string name, string description, CheckStatus status = CheckStatus.New)
            : this()
        {
            Name = name;
            Description = description;
            CheckStatus = status;            
        }

        public Application(Guid id)
            : this()
        {
            Guid = id;
        }

        public Application()
            : base()
        {
            company = new Company();
            contact = new Contact();
            dependingApplications = new List<Guid>();
            adJobContainer = new AdJobContainer() ;
            secGroupContainer = new SecGroupContainer() ;
            menuItemContainer = new MenuItemContainer() ;
            rfMenuItemContainer = new RFMenuItemContainer() ;
            globalsearchcontainer = new GlobalSearchContainer();
            viewgroupContainer = new ViewGroupContainer();
            workstationJobContainer = new WorkstationJobContainer();
            validatorContainer = new ValidatorContainer();
            fieldTypeContainer = new FieldTypeContainer();
            recordContainer = new RecordContainer();
            recordListContainer = new RecordListContainer();
            entityContainer = new EntityContainer();
            workflowCommandContainer = new WorkflowCommandContainer();
            workflowUICommandContainer = new WorkflowUICommandContainer();
            eventContainer = new EventContainer();
            workflowQueryCommandContainer = new WorkflowQueryCommandContainer();
            UpdateDate = DateTime.UtcNow.ToLocalTime();
            ActivationDate = DateTime.MinValue;
            CheckStatus = CheckStatus.New;
            Description =
            ImagesFolder = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public Nullable<DateTime> ActivationDate
        {
            get => activationDate; 
            set => activationDate = value;
        }

        public Nullable<DateTime> CompilationDate
        {
            get => compilationDate;
            set => compilationDate = value;
        }

        public AdJobContainer AdJobContainer
        {
            get
            {
                if (this.adJobContainer == null)
                    this.adJobContainer = new AdJobContainer();
                return this.adJobContainer;
            }
        }

        public SecGroupContainer SecGroupContainer
        {
            get
            {
                if (this.secGroupContainer == null)
                    this.secGroupContainer = new SecGroupContainer();
                return this.secGroupContainer;
            }
        }

        public RFMenuItemContainer RFMenuItemContainer
        {
            get
            {
                if (this.rfMenuItemContainer == null)
                    this.rfMenuItemContainer = new RFMenuItemContainer();
                return this.rfMenuItemContainer;
            }
        }

        public ViewGroupContainer ViewGroupContainer
        {
            get
            {
                if (this.viewgroupContainer == null)
                    this.viewgroupContainer = new ViewGroupContainer();
                return this.viewgroupContainer;
            }
        }

        public ValidatorContainer ValidatorContainer
        {
            get
            {
                if (this.validatorContainer == null)
                    this.validatorContainer = new ValidatorContainer();
                return this.validatorContainer;
            }
        }

        public MenuItemContainer MenuItemContainer
        {
            get
            {
                if (this.menuItemContainer == null)
                    this.menuItemContainer = new MenuItemContainer();
                return this.menuItemContainer;
            }
        }

        public GlobalSearchContainer GlobalSearchContainer
        {
            get
            {
                if (this.globalsearchcontainer == null)
                    this.globalsearchcontainer = new GlobalSearchContainer();
                return this.globalsearchcontainer;
            }
        }

        public WorkstationJobContainer WorkstationJobContainer
        {
            get
            {
                if (this.workstationJobContainer == null)
                    this.workstationJobContainer = new WorkstationJobContainer();
                return this.workstationJobContainer;
            }
        }

        public EventContainer EventContainer
        {
            get
            {
                if (this.eventContainer == null)
                    this.eventContainer = new EventContainer();
                return this.eventContainer;
            }
        }

        public WorkflowCommandContainer WorkflowCommandContainer
        {
            get
            {
                if (this.workflowCommandContainer == null)
                    this.workflowCommandContainer = new WorkflowCommandContainer();
                return this.workflowCommandContainer;
            }
        }

        public WorkflowUICommandContainer WorkflowUICommandContainer
        {
            get
            {
                if (this.workflowUICommandContainer == null)
                    this.workflowUICommandContainer = new WorkflowUICommandContainer();
                return this.workflowUICommandContainer;
            }
        }

        public WorkflowQueryCommandContainer WorkflowQueryCommandContainer
        {
            get
            {
                if (this.workflowQueryCommandContainer == null)
                    this.workflowQueryCommandContainer = new WorkflowQueryCommandContainer();
                return this.workflowQueryCommandContainer;
            }
        }

        public EntityContainer EntityContainer
        {
            get
            {
                if (this.entityContainer == null)
                    this.entityContainer = new EntityContainer();
                return this.entityContainer;
            }
        }

        public Company Company
        {
            get
            {
                if (company == null)
                    company = new Company();
                return company;
            }
            set =>  company = value; 
        }

        public Contact Contact
        {
            get
            {
                if (contact == null)
                    contact = new Contact();
                return contact;
            }
            set => contact = value;
        }

        public string ContactWeb
        {
            get { return this.Contact.Web; }
            set { this.Contact.Web = value; }
        }

        public string Description
        {
            get => description; 
            set => description = value;
        }

        [JsonIgnore]
        public DateTime UpdateDate
        {
            get => updateDate; 
            set => updateDate = value;
        }

        public string ImagesFolder
        {
            get => imagesFolder; 
            set => imagesFolder = value;
        }

        public List<Guid> DependingApplications
        {
            get
            {
                InitializeDependingApplications();
                InitializeDependingApplicationsIndirect();
                return dependingApplications;
            }
            set => dependingApplications = value;
        }

        [JsonIgnore]
        public FieldTypeContainer FieldTypeContainer
        {
            get
            {
                if (this.fieldTypeContainer == null)
                    this.fieldTypeContainer = new FieldTypeContainer();
                return fieldTypeContainer;
            }
        }

        [JsonIgnore]
        public RecordContainer RecordContainer
        {
            get
            {
                if (this.recordContainer == null)
                    this.recordContainer = new RecordContainer();
                return recordContainer;
            }
        }

        [JsonIgnore]
        public RecordListContainer RecordListContainer
        {
            get
            {
                if (this.recordListContainer == null)
                    this.recordListContainer = new RecordListContainer();
                return recordListContainer;
            }
        }
        #endregion

        #region Methods
        private void InitializeDependingApplications()
        {
            if (dependingApplications == null)
                dependingApplications = new List<Guid>();
            if (dependingApplicationsIndirect == null)
                InitializeDependingApplicationsIndirect();
        }

        private void InitializeDependingApplicationsIndirect()
        {
            dependingApplicationsIndirect = new List<Guid>();
        }
        #endregion
    }
}
