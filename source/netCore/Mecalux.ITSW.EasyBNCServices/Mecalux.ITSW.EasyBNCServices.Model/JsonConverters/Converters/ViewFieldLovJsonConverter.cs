using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewFieldLovJsonConverter: EasyBJsonConverter<ViewFieldLov>
    {
        #region Methods

        protected override ViewFieldLov Create(Type objectType)
        {
            return (ViewFieldLov)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ViewFieldLov obj = value as ViewFieldLov;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<ViewFieldLov>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyReference("DependantProperty", obj.DependantProperty, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("DependantViewFieldLOV", obj.DependantViewFieldLOV, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("DisplayProperty", obj.DisplayProperty, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("EntityInternal", obj.EntityInternal, writer, serializer);
                    HelperJsonConverter.WritePropertyObject<Link>("InLineLink", obj.InLineLink, writer, serializer);
                    HelperJsonConverter.WritePropertyObjectsArray("LovsInternal", typeof(List<Lov>), obj.LovsInternal, (objchild) =>
                    {
                        serializer.Serialize(writer, objchild);
                    }, writer, serializer);


                    HelperJsonConverter.WritePropertyValue("OrderLovType", obj.OrderLovType, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("RowLimit", obj.RowLimit, writer, serializer);
                    HelperJsonConverter.WritePropertyValuesArray("ShowPropertiesInternal", typeof(List<Guid>), obj.ShowPropertiesInternal, (objchild) =>
                    {
                        writer.WriteStartObject();
                        HelperJsonConverter.WritePropertyValue("$ref", objchild, writer, serializer);
                        writer.WriteEnd();

                    }, writer, serializer);


                    HelperJsonConverter.WritePropertyValue("SqlOrderBy", obj.SqlOrderBy, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("SqlWhere", obj.SqlWhere, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("ValueProperty", obj.ValueProperty, writer, serializer);
                }
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            ViewFieldLov target = default(ViewFieldLov);
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
