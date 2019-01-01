using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class WorkflowQueryCommandJsonConverter: EasyBJsonConverter<WorkflowQueryCommand>
    {
        #region Methods

        protected override WorkflowQueryCommand Create(Type objectType)
        {
            return (WorkflowQueryCommand)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WorkflowQueryCommand obj = value as WorkflowQueryCommand;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<WorkflowQueryCommand>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyObjectsArray("FormalParametersInternal", typeof(List<WorkflowFormalParameter>), obj.FormalParametersInternal, (objchild) =>
                    {
                        HelperJsonConverter.WritePropertyReference("Attribute", objchild.Attribute, writer, serializer);
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
                    HelperJsonConverter.WritePropertyValue("Expression", obj.Expression, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("IsScalarInternal", obj.IsScalarInternal, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("ParentQueryInternal", obj.ParentQueryInternal, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("QueryType", obj.QueryType, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("VersionId", obj.VersionId, writer, serializer);
                    
                }

            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            WorkflowQueryCommand target = default(WorkflowQueryCommand);
            if (jObject != null)
            {
                target = Create(objectType);
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.VersionId = Guid.Parse(jObject["VersionId"].Value<string>());
                target.Guid = target.VersionId;
                target.Expression = jObject["Expression"].Value<string>();
                target.IsScalarInternal = jObject["IsScalarInternal"].Value<bool>();
                target.Name = jObject["Name"].Value<string>();
                if (jObject["ParentQueryInternal"].HasValues)
                    target.ParentQueryInternal = jObject["ParentQueryInternal"]["$ref"].Value<string>();
                target.QueryType= (WorkflowQueryCommandType)Enum.Parse(typeof(WorkflowQueryCommandType), jObject["QueryType"].Value<string>());

                if (jObject["FormalParametersInternal"]["$values"].HasValues)
                {
                    foreach (var flchild in jObject["FormalParametersInternal"]["$values"])
                    {
                        WorkflowFormalParameter f = new WorkflowFormalParameter();
                        f.Name = flchild["Name"].Value<string>();
                        f.Description = flchild["Name"].Value<string>();
                        f.EntityStereotypeInternal = Guid.Parse(flchild["EntityStereotypeInternal"].Value<string>());
                        f.Index = flchild["Index"].Value<int>();
                        f.IsEditableParameter = flchild["IsEditableParameter"].Value<Boolean>();
                        f.IsRequiredParameter = flchild["IsRequiredParameter"].Value<Boolean>();
                        f.Mode = (WorkflowInOutMode)Enum.Parse(typeof(WorkflowInOutMode), flchild["Mode"].Value<string>());
                        f.Stereotype = (Stereotype)Enum.Parse(typeof(Stereotype), flchild["Stereotype"].Value<string>());
                        f.WorkflowFormalParameterType = (WorkflowFormalParameterType)Enum.Parse(typeof(WorkflowFormalParameterType), flchild["WorkflowFormalParameterType"].Value<string>());
                        if (flchild["Attribute"].HasValues)
                            f.Attribute = flchild["Attribute"]["$ref"].Value<string>();

                        target.AddFormaParameter(f);
                    }
                }

            }
            return target;
        }
        #endregion Methods
    }
}
