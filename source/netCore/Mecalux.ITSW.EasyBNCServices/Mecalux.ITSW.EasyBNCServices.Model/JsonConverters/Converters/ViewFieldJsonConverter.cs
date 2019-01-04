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

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            ViewField target = default(ViewField);
            if (jObject != null)
            {
                target = Create(objectType);
                target.AllowAdvancedSearch = jObject["AllowAdvancedSearch"].Value<bool>();
                target.AllowEdit = jObject["AllowEdit"].Value<bool>();
                target.AllowMassiveUpdate = jObject["AllowMassiveUpdate"].Value<bool>();
                target.AllowMultiEdit = jObject["AllowMultiEdit"].Value<bool>();
                target.AllowSearch = jObject["AllowSearch"].Value<bool>();
                target.ColSpan = jObject["ColSpan"].Value<int>();
                target.DefaultValueCode = jObject["DefaultValueCode"].Value<string>();

                if (jObject["DrillDownLink"].HasValues)
                {
                    Link obj = jObject["DrillDownLink"].ToObject<Link>(serializer);
                    if (obj != null)
                        target.AddDrillDownLink(obj);
                }

                target.EditableCondition = jObject["EditableCondition"].Value<string>();
                target.ImageFalseMode = (ViewFieldImageMode)Enum.Parse(typeof(ViewFieldImageMode), jObject["ImageFalseMode"].Value<string>());
                target.ImageNameFalse = jObject["ImageNameFalse"].Value<string>();
                target.ImageNameTrue = jObject["ImageNameTrue"].Value<string>();
                target.ImageTrueMode = (ViewFieldImageMode)Enum.Parse(typeof(ViewFieldImageMode), jObject["ImageTrueMode"].Value<string>());
                target.IsRequired = jObject["IsRequired"].Value<bool>();
                target.IsVisible = jObject["IsVisible"].Value<bool>();
                target.IsVisibleOnCreation = jObject["IsVisibleOnCreation"].Value<bool>();

                if (jObject["Lov"].HasValues)
                {
                    ViewFieldLov obj = jObject["Lov"].ToObject<ViewFieldLov>(serializer);
                    if (obj != null)
                        target.AddViewFielLov(obj);
                }

                target.Name = jObject["Name"].Value<string>();
                if (jObject["Property"].HasValues)
                    target.Property = jObject["Property"]["$ref"].Value<string>();

                target.ReEvaluateVisibilityOnChange = jObject["ReEvaluateVisibilityOnChange"].Value<bool>();
                target.RequiredCondition = jObject["RequiredCondition"].Value<string>();
                target.RowSpan = jObject["RowSpan"].Value<int>();
                target.SearchResource = jObject["SearchResource"].Value<bool>();
                target.Sequence = jObject["Sequence"].Value<int>();
                target.ShowInCollapsedGrid = jObject["ShowInCollapsedGrid"].Value<bool>();
                target.ShowInExpandedGrid = jObject["ShowInExpandedGrid"].Value<bool>();
                if (jObject["Title"].HasValues)
                    target.Title = jObject["Title"]["$ref"].Value<string>();
                if (jObject["Tooltip"].HasValues)
                    target.Tooltip = jObject["Tooltip"]["$ref"].Value<string>();
                target.UseValueExpressionCode = jObject["UseValueExpressionCode"].Value<bool>();
                if (jObject["Validator"].HasValues)
                    target.Tooltip = jObject["Validator"]["$ref"].Value<string>();
                target.ValidatorCode = jObject["ValidatorCode"].Value<string>();
                if (jObject["ValidatorText"].HasValues)
                    target.Tooltip = jObject["ValidatorText"]["$ref"].Value<string>();
                target.ValueExpressionCode = jObject["ValueExpressionCode"].Value<string>();
                if (jObject["ViewAdvancedSearch"].HasValues)
                    target.Tooltip = jObject["ViewAdvancedSearch"]["$ref"].Value<string>();
                target.ViewAdvancedSearchCode = jObject["ViewAdvancedSearchCode"].Value<string>();
                target.ViewFieldType = (ViewFieldType)Enum.Parse(typeof(ViewFieldType), jObject["ViewFieldType"].Value<string>());
                target.VisibilityCondition = jObject["VisibilityCondition"].Value<string>();
            }
            return target;
        }

        #endregion Methods
    }
}

