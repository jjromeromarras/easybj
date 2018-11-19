using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class WorkflowCommandJsonConverter: EasyBJsonConverter<WorkflowCommand>
    {
        #region Methods

        protected override WorkflowCommand Create(Type objectType)
        {
            return (WorkflowCommand)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WorkflowCommand obj = value as WorkflowCommand;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<WorkflowCommand>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyObjectsArray("FormalParametersInternal", typeof(List<WorkflowFormalParameter>), obj.FormalParametersInternal, (objchild) =>
                    {
                        HelperJsonConverter.WritePropertyObject<WorkflowAttribute>("Attribute", objchild.Attribute, (objatr) => {
                            HelperJsonConverter.WritePropertyValue("Description", objatr.Description, writer, serializer);
                            HelperJsonConverter.WritePropertyValue("EntityStereotypeInternal", objatr.EntityStereotypeInternal, writer, serializer);
                            HelperJsonConverter.WritePropertyValue("InitialValue", objatr.InitialValue, writer, serializer);
                            HelperJsonConverter.WritePropertyValue("Length", objatr.Length, writer, serializer);
                            HelperJsonConverter.WritePropertyValue("Persist", objatr.Persist, writer, serializer);
                            HelperJsonConverter.WritePropertyValue("Stereotype", objatr.Stereotype, writer, serializer);                            
                        }, writer, serializer);

                        //WritePropertyValue("At", objchild.Attribute, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Description", objchild.Description, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("EntityStereotypeInternal", objchild.EntityStereotypeInternal, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Index", objchild.Index, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsEditableParameter", objchild.IsEditableParameter, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsRequiredParameter", objchild.IsRequiredParameter, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Mode", objchild.Mode, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Name", objchild.Name, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Stereotype", objchild.Stereotype, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("WorkflowFormalParameterType", objchild.WorkflowFormalParameterType, writer, serializer);
                    }, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("CheckStatus", obj.CheckStatus, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Description", obj.Description, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("InternalCommandName", obj.InternalCommandName, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("VersionId", obj.VersionId, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("WorkflowCommandType", obj.WorkflowCommandType, writer, serializer);
                }

            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            Record target = default(Record);
            if (jObject != null)
            {
                target = Create(objectType);
                target.AutoUpdateLength = jObject["AutoUpdateLength"].Value<bool>();
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.Guid = Guid.Parse(jObject["Guid"].Value<string>());
                target.RecordType = (RecordType)Enum.Parse(typeof(RecordType), jObject["RecordType"].Value<string>());
                target.Separator = jObject["Separator"].Value<string>();
                target.Name = jObject["Name"].Value<string>();


                foreach (var flchild in jObject["FieldRecordsInternal"]["$values"])
                {
                    FieldRecord f = new FieldRecord();
                    f.Name = flchild["Name"].Value<string>();
                    f.End = flchild["End"].Value<int>();
                    f.Format = flchild["Format"].Value<string>();
                    f.Length = flchild["Length"].Value<int>();
                    f.Guid = Guid.Parse(flchild["Guid"].Value<string>());
                    f.Start = flchild["Start"].Value<int>();
                    f.FieldType = flchild["FieldType"]["$ref"].Value<string>();
                    target.AddFieldRecord(f);
                }

            }
            return target;
        }
        #endregion Methods
    }
}
