using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewFieldJsonConverter : EasyBJsonConverter<ViewField>
    {
        #region Methods

        protected override ViewField Create(Type objectType)
        {
            return (ViewField)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ViewField obj = value as ViewField;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<ViewField>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyValue("AllowAdvancedSearch", obj.AllowAdvancedSearch, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("AllowEdit", obj.AllowEdit, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("AllowMassiveUpdate", obj.AllowMassiveUpdate, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("AllowMultiEdit", obj.AllowMultiEdit, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("AllowSearch", obj.AllowSearch, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ColSpan", obj.ColSpan, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("DefaultValueCode", obj.DefaultValueCode, writer, serializer);
                    HelperJsonConverter.WritePropertyObject<Link>("DrillDownLink", obj.DrillDownLink, writer, serializer);                  
                    HelperJsonConverter.WritePropertyValue("EditableCondition", obj.EditableCondition, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ImageFalseMode", obj.ImageFalseMode, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ImageNameFalse", obj.ImageNameFalse, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ImageNameTrue", obj.ImageNameTrue, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ImageTrueMode", obj.ImageTrueMode, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("IsRequired", obj.IsRequired, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("IsVisible", obj.IsVisible, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("IsVisibleOnCreation", obj.IsVisibleOnCreation, writer, serializer);
                    HelperJsonConverter.WritePropertyObject<ViewFieldLov>("Lov", obj.Lov, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("Property", obj.Property, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ReEvaluateVisibilityOnChange", obj.ReEvaluateVisibilityOnChange, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("RequiredCondition", obj.RequiredCondition, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("RowSpan", obj.RowSpan, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("SearchResource", obj.SearchResource, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Sequence", obj.Sequence, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ShowInCollapsedGrid", obj.ShowInCollapsedGrid, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ShowInExpandedGrid", obj.ShowInCollapsedGrid, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("Title", obj.Title, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("Tooltip", obj.Tooltip, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("UseValueExpressionCode", obj.UseValueExpressionCode, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("Validator", obj.Validator, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ValidatorCode", obj.ValidatorCode, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("ValidatorText", obj.ValidatorText, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ValueExpressionCode", obj.ValueExpressionCode, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("ViewAdvancedSearch", obj.ViewAdvancedSearch, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ViewAdvancedSearchCode", obj.ViewAdvancedSearchCode, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ViewFieldType", obj.ViewFieldType, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("VisibilityCondition", obj.VisibilityCondition, writer, serializer);

                }

            }

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            ViewPageControl target = default(ViewPageControl);
            /*if (jObject != null)
            {
                target = Create(objectType);
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.TableName = jObject["TableName"].Value<string>();
                target.FromMetadata = jObject["FromMetadata"].Value<bool>();
                target.Guid = Guid.Parse(jObject["Guid"].Value<string>());
                target.IsDataWarehouse = jObject["IsDataWarehouse"].Value<bool>();
                target.Name = jObject["Name"].Value<string>();
                target.PluralName = jObject["PluralName"]["$ref"].Value<string>();
                target.SingularName = jObject["SingularName"]["$ref"].Value<string>();

                if (jObject["PropertiesInternal"]["$values"].HasValues)
                    foreach (var flchild in jObject["PropertiesInternal"]["$values"])
                    {
                        Property f = new Property();
                        f.Name = flchild["Name"].Value<string>();
                        f.Guid = Guid.Parse(flchild["Guid"].Value<string>());
                        f.ColumnName = flchild["Name"].Value<string>();
                        f.DataType = (PropertyDataType)Enum.Parse(typeof(PropertyDataType), flchild["DataType"].Value<string>());
                        f.DefaultValue = flchild["DefaultValue"].Value<string>();
                        f.Guid = Guid.Parse(flchild["Guid"].Value<string>());
                        f.Help = flchild["Help"].Value<string>();
                        f.IsActiveProperty = flchild["IsActiveProperty"].Value<bool>();
                        f.IsCustomField = flchild["IsCustomField"].Value<bool>();
                        f.IsDataWarehouse = flchild["IsDataWarehouse"].Value<bool>();
                        f.IsIndex = flchild["IsIndex"].Value<bool>();
                        f.IsPrimaryKey = flchild["IsPrimaryKey"].Value<bool>();
                        f.IsReadOnly = flchild["IsReadOnly"].Value<bool>();
                        f.IsRequiered = flchild["IsRequiered"].Value<bool>();
                        f.IsVisible = flchild["IsVisible"].Value<bool>();
                        f.Lenght = flchild["Lenght"].Value<int>();
                        f.Precision = flchild["Precision"].Value<int>();
                        if (flchild["Title"].HasValues)
                            f.Title = flchild["Title"]["$ref"].Value<string>();
                        if (flchild["Validator"].HasValues)
                            f.Validator = flchild["Validator"]["$ref"].Value<string>();

                        target.AddProperty(f);
                    }
            }*/
            return target;
        }

        #endregion Methods
    }
}
