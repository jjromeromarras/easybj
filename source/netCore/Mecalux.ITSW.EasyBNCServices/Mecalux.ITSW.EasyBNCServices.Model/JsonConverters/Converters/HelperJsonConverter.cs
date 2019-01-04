using Mecalux.ITSW.EasyBCoreServices.Base.Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public static class HelperJsonConverter
    {

        #region Fields

        public const string EntityParticle = "Entity";
        public const string ListParticle = "List";
        public const string FieldTypeParticle = "FieldType";
        public const string DialogParticle = "Dialog";
        public const string RecordParticle = "Record";
        public const string CommandParticle = "Command";
        public const string FopaParticle = "FOPA";
        public const string DialogFormatParticle = "DialogFormat";
        public const string DialogListParticle = "DialogList";
        public const string EventPropertyParticle = "EventProperty";
        public const string EventParticle = "Event";
        public const string QueryParticle = "Query";
        public const string LinkParticle = "Link";
        public const string ViewParticle = "View";
        public const string ViewControlParticle = "ViewControl";
        public const string LovParticle = "LovElement";
        public const string ViewFieldLovParticle = "ViewFieldLov";
        public const string ViewGridForeignFilterParticle = "ViewGridForeignFilter";
        public const string ViewGraphControlSerieParticle = "ViewGraphControlSerie";
        public const string LinkParameterParticle = "LinkParameter";
        public const char Separator = '-';

        /* public const string ActionDataParticle = "ActionData";
         public const string ActionParticle = "Action";
         public const string ActionViewListParticle = "ActionViewList";
         public const string ActivityEventParticle = "ActivityEvent";
         public const string ActivityParticle = "Activity";
         public const string AdJobDataParticle = "AdJobData";
         public const string AttributeParticle = "Attribute";
         
         public const string CommandTagContainerParticle = "CommandTagContainer";
         public const string CommandTagParticle = "CommandTag";
         public const string DeployPackageDataParticle = "DeployPackageData";
         public const string DialogFormatParticle = "DialogFormat";
         public const string DialogListParticle = "DialogList";
         public const string DialogParticle = "Dialog";
         public const string DialogTagContainerParticle = "DialogTagContainer";
         public const string DialogTagParticle = "DialogTag";
         
         public const string EventPropertyParticle = "EventProperty";
         public const string EventTagContainerParticle = "EventTagContainer";
         public const string EventTagParticle = "EventTag";
         
         public const string LanguageDataParticle = "LanguageData";
         public const string LinkParameterParticle = "LinkParameter";
         public const string LinkParticle = "Link";
         
         public const string LovParticle = "LovElement";
         public const string MenuItemDataParticle = "MenuItemData";
         public const string MenuResourceDataParticle = "MenuResourceData";
         public const string MenuResourceLanguageDataParticle = "MenuResourceLanguageData";
         public const string QueryParticle = "Query";
         public const string QueryTagContainerParticle = "QueryTagContainer";
         public const string QueryTagParticle = "QueryTag";
         
         public const string RelationManyToManyParticle = "ManyToMany";
         public const string RelationOneToManyParticle = "OneToMany";
         public const string ReportParticle = "Report";
         public const string RFMenuItemDataParticle = "RFMenuItemData";
         public const string SecGroupDataParticle = "SecGroupData";
         

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
         public static readonly char[] Splitters = { '{', '}' };*/

        #endregion Fields

        // Metodo sacado de NewtonSoft Json:
        // \Newtonsoft.Json.Utilities\ReflectionUtils.cs
        // Limpia información sobrante de los strings de los tipos completos de reflexion. Se usa para que los tipos que escribimos sean igual
        // que los que genera automaticamente la libreria
        public static string RemoveAssemblyDetails(string fullyQualifiedTypeName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            bool flag2 = false;
            foreach (char c in fullyQualifiedTypeName)
            {
                switch (c)
                {
                    case '[':
                        flag = false;
                        flag2 = false;
                        stringBuilder.Append(c);
                        break;

                    case ']':
                        flag = false;
                        flag2 = false;
                        stringBuilder.Append(c);
                        break;

                    case ',':
                        if (!flag)
                        {
                            flag = true;
                            stringBuilder.Append(c);
                        }
                        else
                        {
                            flag2 = true;
                        }
                        break;

                    default:
                        if (!flag2)
                        {
                            stringBuilder.Append(c);
                        }
                        break;
                }
            }
            return stringBuilder.ToString();
        }

        public static void WritePropertyValue(string propertyName, object propertyValue, JsonWriter writer, JsonSerializer serializer)
        {
            writer.WritePropertyName(propertyName);
            serializer.Serialize(writer, propertyValue);
        }

        public static void WritePropertyReference(string propertyName, String reference, JsonWriter writer, JsonSerializer serializer)
        {
            writer.WritePropertyName(propertyName);
            if (String.IsNullOrEmpty(reference))
                writer.WriteNull();
            else
            {
                writer.WriteStartObject();
                WritePropertyValue("$ref", reference, writer, serializer);
                writer.WriteEnd();
            }
        }


        public static void WritePropertyObject<T>(string propertyName, T propertyObject, System.Action<T> serializeObject, JsonWriter writer, JsonSerializer serializer)
                where T : IBaseEntity
        {
            writer.WritePropertyName(propertyName);
            if (propertyObject == null)
                writer.WriteNull();
            else
            {
                writer.WriteStartObject();
                WritePropertyValue("$id", GetReferenceInternal(propertyObject), writer, serializer);
                WritePropertyType(writer, serializer, propertyObject);
                serializeObject.Invoke(propertyObject);
                writer.WriteEnd();
            }
        }

        public static void WritePropertyObject<T>(string propertyName, T propertyObject, JsonWriter writer, JsonSerializer serializer)
            where T : IBaseEntity
        {
            WritePropertyValue(propertyName, propertyObject, writer, serializer);
            writer.WriteEnd();
        }

        public static void WritePropertyObjectsArray<T>(string propertyName, Type collectionType, IEnumerable<T> enumeration, System.Action<T> serializeObject, JsonWriter writer, JsonSerializer serializer)
            where T : IBaseEntity
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStartObject();
            {
                WritePropertyCustomType(writer, serializer, collectionType);
                writer.WritePropertyName("$values");
                writer.WriteStartArray();
                {
                    foreach (T item in enumeration)
                    {
                        writer.WriteStartObject();
                        if (item is IInternalReference)
                        {
                            WritePropertyValue("$id", item.Guid, writer, serializer);
                        }
                        else
                        {
                            WritePropertyValue("$id", GetReferenceInternal(item), writer, serializer);
                        }
                        WritePropertyType(writer, serializer, item);
                        serializeObject.Invoke(item);
                        writer.WriteEnd();
                    }
                }
                writer.WriteEndArray();
            }
            writer.WriteEnd();
        }

        public static void WritePropertyValuesArray<T>(string propertyName, Type collectionType, IEnumerable<T> enumeration, System.Action<T> serializeObject, JsonWriter writer, JsonSerializer serialize)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteStartObject();
            {
                WritePropertyCustomType(writer, serialize, collectionType);
                writer.WritePropertyName("$values");
                writer.WriteStartArray();
                {
                    foreach (T item in enumeration)
                    {
                        serializeObject.Invoke(item);
                    }
                }
                writer.WriteEndArray();
            }
            writer.WriteEnd();
        }

        public static void WritePropertyType<T>(JsonWriter writer, JsonSerializer serialize, T entity = default(T))
        {
            Type type = entity?.GetType() ?? typeof(T);
            string typeName = RemoveAssemblyDetails(type.AssemblyQualifiedName);
            WritePropertyValue("$type", typeName, writer, serialize);
        }

        public static void WritePropertyCustomType(JsonWriter writer, JsonSerializer serialize, Type type)
        {
            string typeName = RemoveAssemblyDetails(type.AssemblyQualifiedName);
            WritePropertyValue("$type", typeName, writer, serialize);
        }

        public static string GetReferenceInternal(IBaseEntity entity)
        {
            string result = string.Empty;

            if (entity != null)
            {
                string particle = TypeParticle(entity);
                NameEntity namedEntity = entity as NameEntity;
                Guid fileGuid = namedEntity.Guid;
                if (IsSplittedType(entity))
                {
                    if (entity is IAvoidSerializedGuid avoidGuidEntity)
                    {
                        Guid versionId = avoidGuidEntity.ParentSerializableEntityVersionId;
                        result = string.Format(CultureInfo.InvariantCulture, "{0}{4}{1}{4}{{{2}}}{4}{3}", avoidGuidEntity.SerializationParticle, TypeParticle(avoidGuidEntity.ParentSerializableEntity), versionId, avoidGuidEntity.ReferencedName, Separator);

                    }
                    else
                    {
                     //   if (entity is IPartiallyOverridableEntity overridable)
                       //     result = overridable.OverriddenVersionId.ToString();
                        //else if (entity is IOverridableEntity overridableEntity)
                          //  result = overridableEntity.OverriddenVersionId.ToString();
                        //else
                            result = entity.Guid.ToString();
                    }                    
                }
                else
                {
                    result = string.Format(CultureInfo.InvariantCulture, "{0}{3}{1}{3}{{{2}}}.{4}", particle, NormalizeName(namedEntity?.Name), fileGuid, Separator, FilesConfig.EasyBPartialExtensionFile);
                }
            }
            return result;
        }

        public static bool IsSplittedType(IBaseEntity entity)
        {
            Type type = entity.GetType();
            return typeof(WorkflowFormalParameter).IsAssignableFrom(type) ||
                    typeof(WorkflowUICommandList).IsAssignableFrom(type) ||
                    typeof(WorkflowUICommandFormat).IsAssignableFrom(type) ||
                    typeof(ViewField).IsAssignableFrom(type) ||
                    typeof(Lov).IsAssignableFrom(type) ||
                    typeof(Link).IsAssignableFrom(type) ||
                    typeof(LinkParameter).IsAssignableFrom(type) ||
                    typeof(ViewFieldLov).IsAssignableFrom(type) ||
                    typeof(EventProperty).IsAssignableFrom(type);
                    
                 
        }
        public static string NormalizeName(string input)
        {
            string result = input?.Replace("?", "_nullable") ?? string.Empty;
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                result = result.Replace(c, '_');
            return result;
        }

       
        private static string TypeParticle(IBaseEntity entity)
        {
            if (entity != null)
            {

                if (typeof(FieldType).IsAssignableFrom(entity.GetType()))
                    return FieldTypeParticle;
                else if (typeof(Record).IsAssignableFrom(entity.GetType()))
                    return RecordParticle;
                else if (typeof(RecordList).IsAssignableFrom(entity.GetType()))
                    return ListParticle;
                else if (typeof(Entity).IsAssignableFrom(entity.GetType()))
                    return EntityParticle;
                else if (typeof(WorkflowCommand).IsAssignableFrom(entity.GetType()))
                    return CommandParticle;
                else if (typeof(WorkflowFormalParameter).IsAssignableFrom(entity.GetType()))
                    return FopaParticle;
                else if (typeof(WorkflowUICommand).IsAssignableFrom(entity.GetType()))
                    return DialogParticle;
                else if (typeof(Event).IsAssignableFrom(entity.GetType()))
                    return EventParticle;
                else if (typeof(View).IsAssignableFrom(entity.GetType()) ||
                    typeof(ViewField).IsAssignableFrom(entity.GetType()) ||
                    typeof(ViewPanel).IsAssignableFrom(entity.GetType()) 
                    )
                    return ViewParticle;
                else if (typeof(WorkflowQueryCommand).IsAssignableFrom(entity.GetType()))
                    return QueryParticle;

            }
            return string.Empty;
        }
    }
}
