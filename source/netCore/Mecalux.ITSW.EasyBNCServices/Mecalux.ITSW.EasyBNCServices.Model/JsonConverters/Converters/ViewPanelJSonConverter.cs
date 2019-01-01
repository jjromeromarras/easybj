using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewPanelJsonConverter: EasyBJsonConverter<ViewPanel>
    {
        #region Methods

        protected override ViewPanel Create(Type objectType)
        {
            return (ViewPanel)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ViewPanel obj = value as ViewPanel;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<ViewPanel>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyValue("ColCount", obj.ColCount, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ColSpan", obj.ColCount, writer, serializer);

                    HelperJsonConverter.WritePropertyObjectsArray("ControlsInternal", typeof(List<ViewControl>), obj.ControlsInternal, (objchild) =>
                    {
                        HelperJsonConverter.WritePropertyValue("ColSpan", objchild.ColSpan, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Name", objchild.Name, writer, serializer);
                        ViewPageControl vpc = (objchild as ViewPageControl);
                        if (vpc != null)
                        {
                            HelperJsonConverter.WritePropertyObjectsArray("ControlsInternal", typeof(List<ViewPanelPage>), vpc.PagesInternal, (objpage) =>
                            {
                                HelperJsonConverter.WritePropertyValue("ColCount", objpage.ColCount, writer, serializer);
                                HelperJsonConverter.WritePropertyValue("ColSpan", objpage.ColSpan, writer, serializer);

                                HelperJsonConverter.WritePropertyValue("DefaultPage", objpage.DefaultPage, writer, serializer);
                                HelperJsonConverter.WritePropertyValue("Name", objpage.Name, writer, serializer);
                                HelperJsonConverter.WritePropertyValue("PageNumber", objpage.PageNumber, writer, serializer);
                                HelperJsonConverter.WritePropertyValue("RowCount", objpage.RowCount, writer, serializer);
                                HelperJsonConverter.WritePropertyValue("RowSpan", objpage.RowSpan, writer, serializer);
                                HelperJsonConverter.WritePropertyValue("Sequence", objpage.Sequence, writer, serializer);
                                HelperJsonConverter.WritePropertyReference("Title", objpage.Title, writer, serializer);
                                HelperJsonConverter.WritePropertyValue("VisibilityCondition", objchild.VisibilityCondition, writer, serializer);
                            }, writer, serializer);
                        }
                        HelperJsonConverter.WritePropertyValue("RowSpan", objchild.RowSpan, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Sequence", objchild.Sequence, writer, serializer);
                        HelperJsonConverter.WritePropertyReference("Title", objchild.Title, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("VisibilityCondition", objchild.VisibilityCondition, writer, serializer);
                    }, writer, serializer);

                    HelperJsonConverter.WritePropertyObjectsArray("FieldsInternal", typeof(List<ViewField>), obj.FieldsInternal, (objfield) =>
                    {
                    }, writer, serializer);

                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("RowCount", obj.RowCount, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("RowSpan", obj.RowSpan, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Sequence", obj.Sequence, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("Title", obj.Title, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("VisibilityCondition", obj.VisibilityCondition, writer, serializer);
                }

            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            ViewPanel target = default(ViewPanel);
           /* if (jObject != null)
            {
                target = Create(objectType);
                target.CheckDigit = (CheckDigit)Enum.Parse(typeof(CheckDigit), jObject["CheckDigit"].Value<string>());
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.EditionLengthMode = (EditionLengthMode)Enum.Parse(typeof(EditionLengthMode), jObject["EditionLengthMode"].Value<string>());
                target.EntityStereotypeInternal = Guid.Parse(jObject["EntityStereotypeInternal"].Value<string>());
                target.FillMode = (FillMode)Enum.Parse(typeof(FillMode), jObject["FillMode"].Value<string>());
                target.Guid = Guid.Parse(jObject["Guid"].Value<string>());
                target.InputMask = jObject["InputMask"].Value<string>();
                target.Length = jObject["Length"].Value<int>();
                target.Name = jObject["Name"].Value<string>();
                target.Stereotype = (Stereotype)Enum.Parse(typeof(Stereotype), jObject["Stereotype"].Value<string>());
                target.TruncateType = (TruncateType)Enum.Parse(typeof(TruncateType), jObject["TruncateType"].Value<string>());
            }*/
            return target;
        }
        #endregion Methods
    }
}
