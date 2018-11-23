using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    public class WorkflowUICommandJsonConverter : EasyBJsonConverter<WorkflowUICommand>
    {
        #region Methods

        protected override WorkflowUICommand Create(Type objectType)
        {
            return (WorkflowUICommand)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WorkflowUICommand obj = value as WorkflowUICommand;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<WorkflowUICommand>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyObjectsArray("FormatsInternal", typeof(List<WorkflowUICommandFormat>), obj.FormatsInternal, (objchild) =>
                    {
                        HelperJsonConverter.WritePropertyValue("Height", objchild.Height, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsDefault", objchild.IsDefault, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Name", objchild.Name, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("UIXml", objchild.UIXml, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Width", objchild.Width, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("WorkflowUICommandFormatType", objchild.WorkflowUICommandFormatType, writer, serializer);
                    }, writer, serializer);
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
                    HelperJsonConverter.WritePropertyValuesArray("OptionsInternal", typeof(List<string>), obj.OptionsInternal, (objchild) => 
                    {
                        writer.WriteValue(objchild);
                    }, writer, serializer);
                    HelperJsonConverter.WritePropertyObjectsArray("ListsInternal", typeof(List<WorkflowUICommandList>), obj.ListsInternal, (objchild) =>
                    {
                        HelperJsonConverter.WritePropertyReference("DefaultValueParameterName", objchild.DefaultValueParameterName, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Name", objchild.Name, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("NavigationAllowsNullSelection", objchild.NavigationAllowsNullSelection, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("NavigationNextOptionInternal", objchild.NavigationNextOptionInternal, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("NavigationNextPageOptionInternal", objchild.NavigationNextPageOptionInternal, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("NavigationNullSelectionText", objchild.NavigationNullSelectionText, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("NavigationOptionsExitsDialog", objchild.NavigationOptionsExitsDialog, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("NavigationPreviousOptionInternal", objchild.NavigationPreviousOptionInternal, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("NavigationPreviousPageOptionInternal", objchild.NavigationPreviousPageOptionInternal, writer, serializer);
                        HelperJsonConverter.WritePropertyReference("SelectedValueParameterName", objchild.SelectedValueParameterName, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("SelectOptionDisplayLabelText", objchild.SelectOptionDisplayLabelText, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("SelectOptionDisplayProperty", objchild.SelectOptionDisplayProperty, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("SelectOptionExitDialogOptionInternal", objchild.SelectOptionExitDialogOptionInternal, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("SelectOptionExitsDialog", objchild.SelectOptionExitsDialog, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("SelectOptionInternal", objchild.SelectOptionInternal, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("SelectOptionOnlyList", objchild.SelectOptionOnlyList, writer, serializer);
                    }, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("CheckStatus", obj.CheckStatus, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Description", obj.Description, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("IsSelector", obj.IsSelector, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("SelectorList", obj.SelectorList, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ShowPromptDefaultValue", obj.ShowPromptDefaultValue, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("VersionId", obj.VersionId, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("WorkflowUICommandEditionKind", obj.WorkflowUICommandEditionKind, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("WorkflowUICommandPromptTypeInternal", obj.WorkflowUICommandPromptTypeInternal, writer, serializer);
                }

            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            WorkflowCommand target = default(WorkflowCommand);
           /* if (jObject != null)
            {
                target = Create(objectType);
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.VersionId = Guid.Parse(jObject["VersionId"].Value<string>());
                target.Guid = target.VersionId;
                target.InternalCommandName = jObject["InternalCommandName"].Value<string>();
                target.Name = jObject["Name"].Value<string>();
                target.WorkflowCommandType = (WorkflowCommandType)Enum.Parse(typeof(WorkflowCommandType), jObject["WorkflowCommandType"].Value<string>());

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

            }*/
            return target;
        }
        #endregion Methods
    }
}
