using Mecalux.ITSW.EasyBServices.Base.Files;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class GuidReferenceResolver : IReferenceResolver
    {

        #region Fields

        public const string ActionDataParticle = "ActionData";
        public const string ActionParticle = "Action";
        public const string ActionViewListParticle = "ActionViewList";
        public const string ActivityEventParticle = "ActivityEvent";
        public const string ActivityParticle = "Activity";
        public const string AdJobDataParticle = "AdJobData";
        public const string AttributeParticle = "Attribute";
        public const string CommandParticle = "Command";
        public const string CommandTagContainerParticle = "CommandTagContainer";
        public const string CommandTagParticle = "CommandTag";
        public const string DeployPackageDataParticle = "DeployPackageData";
        public const string DialogFormatParticle = "DialogFormat";
        public const string DialogListParticle = "DialogList";
        public const string DialogParticle = "Dialog";
        public const string DialogTagContainerParticle = "DialogTagContainer";
        public const string DialogTagParticle = "DialogTag";
        public const string EntityParticle = "Entity";
        public const string EventParticle = "Event";
        public const string EventPropertyParticle = "EventProperty";
        public const string EventTagContainerParticle = "EventTagContainer";
        public const string EventTagParticle = "EventTag";
        public const string FieldTypeParticle = "FieldType";
        public const string FopaParticle = "FOPA";
        public const string LanguageDataParticle = "LanguageData";
        public const string LinkParameterParticle = "LinkParameter";
        public const string LinkParticle = "Link";
        public const string ListParticle = "List";
        public const string LovParticle = "LovElement";
        public const string MenuItemDataParticle = "MenuItemData";
        public const string MenuResourceDataParticle = "MenuResourceData";
        public const string MenuResourceLanguageDataParticle = "MenuResourceLanguageData";
        public const string QueryParticle = "Query";
        public const string QueryTagContainerParticle = "QueryTagContainer";
        public const string QueryTagParticle = "QueryTag";
        public const string RecordParticle = "Record";
        public const string RelationManyToManyParticle = "ManyToMany";
        public const string RelationOneToManyParticle = "OneToMany";
        public const string ReportParticle = "Report";
        public const string RFMenuItemDataParticle = "RFMenuItemData";
        public const string SecGroupDataParticle = "SecGroupData";
        public const char Separator = '-';
        public const string SubscriptionParameterParticle = "SubscriptionParameter";
        public const string SubscriptionParticle = "Subscription";
        public const string SubscriptionTagContainerParticle = "SubscriptionTagContainer";
        public const string SubscriptionTagParticle = "SubscriptionTag";
        public const string TransitionParticle = "Transition";
        public const string ViewControlParticle = "ViewControl";
        public const string ViewFieldLovParticle = "ViewFieldLov";
        public const string ViewGraphControlSerieParticle = "ViewGraphControlSerie";
        public const string ViewGridForeignFilterParticle = "ViewGridForeignFilter";
        public const string ViewGroupDataParticle = "ViewGroupData";
        public const string ViewParameterParticle = "ViewParameter";
        public const string ViewParticle = "View";
        public const string ViewTagContainerParticle = "ViewTagContainer";
        public const string ViewTagParticle = "ViewTag";
        public const string ViewWorkstationJobParticle = "ViewWorkstationJob";
        public const string WorkflowDialogEventParticle = "DialogEvent";
        public const string WorkflowParticle = "Workflow";
        public const string WorkflowTagContainerParticle = "WorkflowTagContainer";
        public const string WorkflowTagParticle = "WorkflowTag";
        public static readonly char[] Splitters = { '{', '}' };
        private static readonly int MaxParseTries = 10;
        private static readonly object typesAvoidLocker = new object();
        private static string currentApp;
        private static Dictionary<string, PartialReferences> fullReferences;
        private static List<string> typesAvoid;

        #endregion Fields

        #region Constructors

        static GuidReferenceResolver()
        {
            fullReferences = new Dictionary<string, PartialReferences>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Aplicacion activa actualmente
        /// </summary>
        public static ApplicationTagContainer ApplicationTagContainer
        {
            get
            {
                return CurrentReferences.ApplicationTagContainer;
            }
            set
            {
                currentApp = value?.Name ?? string.Empty;
                CurrentReferences.ApplicationTagContainer = value;
            }
        }

        public static bool DisablePartialReferences { set; get; }
        //public static ImportPart Importer { set; get; }

        public static ConcurrentDictionary<Type, IList<JsonProperty>> OrderedProperties { get { return CurrentReferences.OrderedProperties; } }

        public static string ReferencesPath { set; get; }

        private static string CurrentApplication
        {
            get { return DisablePartialReferences ? string.Empty : currentApp ?? string.Empty; }
        }

        private static PartialReferences CurrentReferences => ReferencePartialOfApplication(CurrentApplication);
        private static ConcurrentDictionary<Guid, IBaseEntity> References { get { return CurrentReferences.References; } }
        private static ConcurrentDictionary<string, IBaseEntity> ReferencesAvoidedGuid { get { return CurrentReferences.ReferencesAvoidedGuid; } }
        private static ConcurrentDictionary<Guid, HashSet<string>> referencesByVersionId { get { return CurrentReferences.ReferencesByVersionId; } }
        private ConcurrentDictionary<int, object> ReferenceObjects { get { return CurrentReferences.ReferenceObjects; } }

        #endregion Properties

        #region Methods
        public void AddReference(object context, string reference, object value)
        {
            
        }

        public string GetReference(object context, object value)
        {
            string result = string.Empty;


            if (value is IBaseEntity p)
            {
                References[p.Guid] = p;
                result = GetReferenceInternal(p);
            }
            else
            {
                int i = ReferenceObjects.Count;
                ReferenceObjects[i] = value;
                result = i.ToString();
            }
            return result;
        }

        public bool IsReferenced(object context, object value)
        {
            return false;
        }

        public object ResolveReference(object context, string reference)
        {
            throw new System.NotImplementedException();
        }

        private static PartialReferences ReferencePartialOfApplication(string application)
        {
            if (!fullReferences.TryGetValue(application, out PartialReferences references))
            {
                references = new PartialReferences();
                fullReferences[application] = references;
            }
            return references;
        }

        public string GetReferenceInternal(IBaseEntity entity)
        {
            string result = string.Empty;

            if (entity != null)
            {
                string particle = TypeParticle(entity);
                NameEntity namedEntity = entity as NameEntity;
                Guid fileGuid = GetParentGuid(namedEntity);
                result = string.Format(CultureInfo.InvariantCulture, "{0}{3}{1}{3}{{{2}}}.{4}", particle, NormalizeName(namedEntity?.Name), fileGuid, Separator, FilesConfig.EasyBPartialExtensionFile);
            }
            return result;
        }

        public string NormalizeName(string input)
        {
            string result = input?.Replace("?", "_nullable") ?? string.Empty;
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                result = result.Replace(c, '_');
            return result;
        }

        private Guid GetParentGuid(NameEntity namedEntity)
        {
            Guid result = namedEntity.Guid;
            /*if (namedEntity is IPartiallyOverridableEntity overridable && overridable.IsPartiallyOverridden)
                result = overridable.OverriddenVersionId.Value;
            else if (namedEntity is IOverridableEntity overridableEntity && overridableEntity.IsOverridden)
                result = overridableEntity.OverriddenVersionId.Value;
            else if (namedEntity.ParentEntity != null && namedEntity.ParentEntity.ParentEntity != null && HasParentTagContainer(namedEntity))
                result = namedEntity.ParentEntity.ParentEntity.Guid;*/
            return result;
        }

        private string TypeParticle(IBaseEntity entity)
        {
            if (entity != null)
            {

                if (typeof(FieldType).IsAssignableFrom(entity.GetType()))
                    return FieldTypeParticle;
                if (typeof(Record).IsAssignableFrom(entity.GetType()))
                    return RecordParticle;

                /*if (typeof(Workflow).IsAssignableFrom(entity.GetType()) ||
                    typeof(WorkflowTagContainer).IsAssignableFrom(entity.GetType()))
                    return WorkflowParticle;
                if (typeof(WorkflowUICommand).IsAssignableFrom(entity.GetType()) ||
                    typeof(WorkflowUICommandTagContainer).IsAssignableFrom(entity.GetType()))
                    return DialogParticle;
                if (typeof(WorkflowQueryCommand).IsAssignableFrom(entity.GetType()) ||
                    typeof(WorkflowQueryCommandTagContainer).IsAssignableFrom(entity.GetType()))
                    return QueryParticle;
                if (typeof(View).IsAssignableFrom(entity.GetType()) ||
                    typeof(ViewTagContainer).IsAssignableFrom(entity.GetType()))
                    return ViewParticle;
                if (typeof(WorkflowCommand).IsAssignableFrom(entity.GetType()) ||
                    typeof(CommandTagContainer).IsAssignableFrom(entity.GetType()))
                    return CommandParticle;
                if (typeof(Entity).IsAssignableFrom(entity.GetType()))
                    return EntityParticle;
                if (typeof(Event).IsAssignableFrom(entity.GetType()) ||
                    typeof(EventTagContainer).IsAssignableFrom(entity.GetType()))
                    return EventParticle;
                if (typeof(EventProperty).IsAssignableFrom(entity.GetType()))
                    return EventPropertyParticle;
                if (typeof(RecordList).IsAssignableFrom(entity.GetType()))
                    return ListParticle;
                if (typeof(Report).IsAssignableFrom(entity.GetType()))
                    return ReportParticle;
                if (typeof(Subscription).IsAssignableFrom(entity.GetType()) ||
                    typeof(SubscriptionTagContainer).IsAssignableFrom(entity.GetType()))
                    return SubscriptionParticle;
                if (typeof(WorkflowDialogActivityEvent).IsAssignableFrom(entity.GetType()))
                    return WorkflowDialogEventParticle;
                if (typeof(WorkflowActivity).IsAssignableFrom(entity.GetType()))
                    return ActivityParticle;*/
            }
            return string.Empty;
        }
        #endregion
    }
}
