using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class LovJsonConverter : EasyBJsonConverter<Lov>
    {
        #region Methods

        protected override Lov Create(Type objectType)
        {
            return (Lov)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Lov obj = value as Lov;
            if (obj != null)
            {
                HelperJsonConverter.WritePropertyReference("DisplayValue", obj.DisplayValue, writer, serializer);
                HelperJsonConverter.WritePropertyValue("Value", obj.Value, writer, serializer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            Lov target = default(Lov);
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
