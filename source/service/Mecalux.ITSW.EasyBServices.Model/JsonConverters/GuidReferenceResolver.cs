using Mecalux.ITSW.EasyBServices.Base.Files;
using Mecalux.ITSW.EasyBServices.Model.Interfaz;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Mecalux.ITSW.EasyBServices.Model.JsonConverters
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

        #region Delegates

        public delegate BaseEntity ImportPart(string pathName);

        #endregion Delegates

        #region Properties

        /// <summary>
        /// Aplicacion activa actualmente
        /// </summary>
        /*public static ApplicationTagContainer ApplicationTagContainer
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
        }*/

        public static bool DisablePartialReferences { set; get; }
        public static ImportPart Importer { set; get; }

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
        /*IEnumerable<ApplicationTagContainer> GetDependingApplications()
        {
            List<ApplicationTagContainer> applications = new List<ApplicationTagContainer>();
            IEnumerable<Guid> applicationGuids = ApplicationTagContainer?.LastEntity.DependingApplications.Reverse();
            if (applicationGuids != null)
            {
                foreach (Guid applicationGuid in applicationGuids)
                {
                    if (ActiveModelData.TryGetValue(applicationGuid, out ApplicationTagContainer applicationTagContainer))
                    {
                        applications.Add(applicationTagContainer);
                    }
                }
            }
            return applications;
        }*/

        public object ResolveReference(object context, string reference)
        {
            /*object result = ResolveReference(context, reference, CurrentApplication, ApplicationTagContainer);
            if (result == null)
            {
                IEnumerable<ApplicationTagContainer> currentAppDependants = GetDependingApplications();
                if (currentAppDependants != null)
                {
                    foreach (var applicationTagContainer in currentAppDependants)
                    {
                        result = ResolveReference(context, reference, applicationTagContainer.Name, applicationTagContainer);
                        if (result != null)
                            break;
                    }
                }
                if (result == null && !BaseEntity.LogTraceDisabled)
                    if (CurrentApplicationIsOk(ApplicationTagContainer))
                        AddLogErrorGettingReference(ApplicationTagContainer, reference, "Error finding element with reference {0}");
            }

            return result;
            */
            return null;
            
        }

        


        public string GetReference(object context, object value)
        {
            string result = string.Empty;

            if (value is IBaseEntity p)
            {
                if (p is IAvoidSerializedGuid avoidedGuid)
                {
                    result = GetReferenceInternal(p);
                    ReferencesAvoidedGuid[result] = p;
                }
                else
                {
                    References[p.Guid] = p;
                    result = GetReferenceInternal(p);
                }
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
            bool result = false;
            if (value is IAvoidSerializedGuid avoidedGuid)
                lock (ReferencesAvoidedGuid)
                {
                  //  if (avoidedGuid is View view)
                    //    result = view.DependsOtherView == null;
                    //else
                        result = ReferencesAvoidedGuid.ContainsKey(GetReferenceInternal(avoidedGuid));
                }
            else
            {
                if (value is IBaseEntity p)
                {
                    if (!IsSplittedType(p))
                    {
                       // if (IsAllwaysAvoidRefType(p))
                         //   return false;
                        //else
                            lock (References)
                            {
                                result = References.ContainsKey(p.Guid);
                            }
                    }
                    else
                    {
                    //    if (p is View view)
                      //      result = view.DependsOtherView == null;
                        //else
                            result = true;
                    }
                }
                else
                {
                    if (value is Dictionary<string, object>)
                        result = false;
                    else
                        result = ReferenceObjects.Any(v => v.Value == value);
                }
            }
            return result;
        }

       // public static bool IsAllwaysAvoidRefType(IBaseEntity entity)
      //  {
        //    Type type = entity.GetType();
          //  return typeof(FieldRecord).IsAssignableFrom(type);
       // }

        public void AddReference(object context, string reference, object value)
        {
            if (value is IBaseEntity p)
            {
                if (IsIAvoidSerializedGuid(reference))
                {
                    lock (ReferencesAvoidedGuid)
                    {
                        ReferencesAvoidedGuid[reference] = p;

                        if (p is IAvoidSerializedGuid avoidGuidEntity)
                        {
                            Guid versionId = ExtractFromReferenceGuid(reference);
                            lock (referencesByVersionId)
                            {
                                if (!referencesByVersionId.ContainsKey(versionId))
                                    referencesByVersionId[versionId] = new HashSet<string>();
                                referencesByVersionId[versionId].Add(reference);
                            }
                        }
                    }
                }
                else
                {
                    Guid id = ParseGuidFromReference(reference);
                    lock (References)
                        References[id] = p;
                }
            }
            else
            {
                if (int.TryParse(reference, out int i))
                {
                    lock (ReferenceObjects)
                        ReferenceObjects[i] = value;
                }
            }
        }

        private static Guid ParseGuidFromReference(string reference)
        {
            Guid id = default(Guid);
            string[] referenceParts = reference.Split(Splitters);
            int q = 0;
            while (!Guid.TryParse(referenceParts[q], out id) && q < MaxParseTries)
                q++;
            return id;
        }

        public static Guid ExtractFromReferenceGuid(string reference)
        {
            string[] parts = reference.Split(Splitters);
            Guid guid = Guid.Parse(parts[1]);
            return guid;
        }

        public static bool IsIAvoidSerializedGuid(string reference)
        {
            lock (typesAvoidLocker)
                if (typesAvoid == null)
                {
                    typesAvoid = new List<string>
                    {
                        EventParticle,
                        EventPropertyParticle,
                        EventTagParticle,
                        EventTagContainerParticle,
                        EntityParticle,
                        SubscriptionParticle,
                        SubscriptionTagParticle,
                        SubscriptionParameterParticle,
                        ViewTagParticle,
                        ViewControlParticle,
                        ActivityParticle,
                        WorkflowTagParticle,
                        AttributeParticle,
                        CommandTagParticle,
                        FopaParticle,
                        QueryTagParticle,
                        TransitionParticle,
                        DialogTagParticle,
                        ViewTagContainerParticle,
                        DialogTagContainerParticle,
                        QueryTagContainerParticle,
                        CommandTagContainerParticle,
                        WorkflowTagContainerParticle,
                        SubscriptionTagContainerParticle,
                        ViewFieldLovParticle,
                        LinkParticle,
                        ViewParameterParticle,
                        ViewGraphControlSerieParticle,
                        ViewGridForeignFilterParticle,
                        WorkflowDialogEventParticle,
                        // Package types
                        ActionDataParticle,
                        AdJobDataParticle,
                        DeployPackageDataParticle,
                        LanguageDataParticle,
                        MenuItemDataParticle,
                        RFMenuItemDataParticle,
                        MenuResourceDataParticle,
                        MenuResourceLanguageDataParticle,
                        SecGroupDataParticle,
                        ViewGroupDataParticle
                    };
                }
            return typesAvoid.Exists(x => reference.StartsWith(x + Separator));
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
        public static string GetReferenceInternal(IBaseEntity entity)
        {
            string result = string.Empty;

            if (entity == null)
            {
            }
            else if (!IsSplittedType(entity))
            {
                if (entity is IAvoidSerializedGuid avoidGuidEntity)
                {
                    Guid versionId = avoidGuidEntity.ParentSerializableEntityVersionId;
                    result = string.Format(CultureInfo.InvariantCulture, "{0}{4}{1}{4}{{{2}}}{4}{3}", avoidGuidEntity.SerializationParticle, TypeParticle(avoidGuidEntity.ParentSerializableEntity), versionId, avoidGuidEntity.ReferencedName, Separator);
                    lock (referencesByVersionId)
                    {
                        if (!referencesByVersionId.ContainsKey(versionId))
                            referencesByVersionId[versionId] = new HashSet<string>();
                        referencesByVersionId[versionId].Add(result);
                    }
                }
                else
                {
                    if (entity is IPartiallyOverridableEntity overridable)
                        result = overridable.OverriddenVersionId.ToString();
                    else if (entity is IOverridableEntity overridableEntity)
                        result = overridableEntity.OverriddenVersionId.ToString();
                    else
                        result = entity.Guid.ToString();
                }
            }
            else
            {
                string particle = TypeParticle(entity);
                BaseEntity namedEntity = entity as BaseEntity;
                Guid fileGuid = GetParentGuid(namedEntity);
                result = string.Format(CultureInfo.InvariantCulture, "{0}{3}{1}{3}{{{2}}}.{4}", particle, NormalizeName(namedEntity?.Name), fileGuid, Separator, FilesConfig.EasyBPartialExtensionFile);
            }
            return result;
        }

        public static string NormalizeName(string input)
        {
            string result = input?.Replace("?", "_nullable") ?? string.Empty;
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                result = result.Replace(c, '_');
            return result;
        }

        public static bool IsSplittedType(IBaseEntity entity)
        {
            Type type = entity.GetType();
            /*return typeof(Workflow).IsAssignableFrom(type) ||
                 typeof(Event).IsAssignableFrom(type) ||
                 typeof(Entity).IsAssignableFrom(type) ||
                 typeof(WorkflowCommand).IsAssignableFrom(type) ||
                 typeof(WorkflowUICommand).IsAssignableFrom(type) ||
                 typeof(WorkflowQueryCommand).IsAssignableFrom(type) ||
                 typeof(View).IsAssignableFrom(type) ||
                 typeof(Record).IsAssignableFrom(type) ||
                 typeof(RecordList).IsAssignableFrom(type) ||
                 typeof(FieldType).IsAssignableFrom(type) ||
                 typeof(Subscription).IsAssignableFrom(type) ||
                 typeof(Report).IsAssignableFrom(type);*/
            return false;
        }

        private static string TypeParticle(IBaseEntity entity)
        {
            /*if (entity != null)
            {
                if (typeof(Workflow).IsAssignableFrom(entity.GetType()) ||
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
                if (typeof(FieldType).IsAssignableFrom(entity.GetType()))
                    return FieldTypeParticle;
                if (typeof(Record).IsAssignableFrom(entity.GetType()))
                    return RecordParticle;
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
                    return ActivityParticle;
            }*/
            return string.Empty;
        }

        private static Guid GetParentGuid(BaseEntity namedEntity)
        {
            Guid result = namedEntity.Guid;
            if (namedEntity is IPartiallyOverridableEntity overridable && overridable.IsPartiallyOverridden)
                result = overridable.OverriddenVersionId.Value;
            else if (namedEntity is IOverridableEntity overridableEntity && overridableEntity.IsOverridden)
                result = overridableEntity.OverriddenVersionId.Value;
            return result;
        }
        #endregion Methods
    }
}
