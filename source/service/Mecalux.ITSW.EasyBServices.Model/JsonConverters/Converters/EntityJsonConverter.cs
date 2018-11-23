using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class EntityJsonConverter: EasyBJsonConverter<Entity>
    {
        #region Methods

        protected override Entity Create(Type objectType)
        {
            return (Entity)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Entity obj = value as Entity;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<Entity>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyValue("CheckStatus", obj.CheckStatus, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Description", obj.Description, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("FromMetadata", obj.FromMetadata, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Guid", obj.Guid, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("IsDataWarehouse", obj.IsDataWarehouse, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("IsNew", obj.IsNew, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("PluralName", obj.PluralName, writer, serializer);

                    HelperJsonConverter.WritePropertyObjectsArray("PropertiesInternal", typeof(List<Property>), obj.PropertiesInternal, (objchild) =>
                    {
                        HelperJsonConverter.WritePropertyValue("ColumnName", objchild.ColumnName, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("DataType", objchild.DataType, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("DefaultValue", objchild.DefaultValue, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Guid", objchild.Guid, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Help", objchild.Help, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsActiveProperty", objchild.IsActiveProperty, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsCustomField", objchild.IsCustomField, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsDataWarehouse", objchild.IsDataWarehouse, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsIndex", objchild.IsIndex, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsPrimaryKey", objchild.IsPrimaryKey, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsReadOnly", objchild.IsReadOnly, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsRequiered", objchild.IsRequiered, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("IsVisible", objchild.IsVisible, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Lenght", objchild.Lenght, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Name", objchild.Name, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Precision", objchild.Precision, writer, serializer);
                        HelperJsonConverter.WritePropertyReference("Title", objchild.Title, writer, serializer);
                        HelperJsonConverter.WritePropertyReference("Validator", objchild.Validator, writer, serializer);

                    }, writer, serializer);

                    HelperJsonConverter.WritePropertyReference("SingularName", obj.SingularName, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("TableName", obj.TableName, writer, serializer);

                }

            }

        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            Entity target = default(Entity);
            if (jObject != null)
            {
                target = Create(objectType);
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.TableName = jObject["TableName"].Value<string>();
                target.FromMetadata = jObject["FromMetadata"].Value<bool>();
                target.Guid = Guid.Parse(jObject["Guid"].Value<string>());
                target.IsDataWarehouse= jObject["IsDataWarehouse"].Value<bool>();
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
            }
            return target;
        }
        
        #endregion Methods
    }
}
