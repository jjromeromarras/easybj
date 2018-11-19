using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class FieldTypeJsonConverter: EasyBJsonConverter<FieldType>
    {
        #region Methods

        protected override FieldType Create(Type objectType)
        {
            return (FieldType)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            FieldType obj = value as FieldType;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<FieldType>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyValue("CheckDigit", obj.CheckDigit, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("CheckStatus", obj.CheckStatus, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Description", obj.Description, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("EditionLengthMode", obj.EditionLengthMode, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("EntityStereotypeInternal", obj.EntityStereotypeInternal, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("FillMode", obj.FillMode, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Guid", obj.Guid, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("InputMask", obj.InputMask, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Length", obj.Length, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Stereotype", obj.Stereotype, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("TruncateType", obj.TruncateType, writer, serializer);
                }

            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            FieldType target = default(FieldType);
            if (jObject != null)
            {
                target = Create(objectType);
                target.CheckDigit = (CheckDigit)Enum.Parse(typeof(CheckDigit), jObject["CheckDigit"].Value<string>());
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.EditionLengthMode = (EditionLengthMode)Enum.Parse(typeof(EditionLengthMode), jObject["EditionLengthMode"].Value<string>());
                target.EntityStereotypeInternal = Guid.Parse(jObject["EntityStereotypeInternal"].Value<string>());
                target.FillMode= (FillMode)Enum.Parse(typeof(FillMode), jObject["FillMode"].Value<string>());
                target.Guid = Guid.Parse(jObject["Guid"].Value<string>());
                target.InputMask = jObject["InputMask"].Value<string>();
                target.Length = jObject["Length"].Value<int>();
                target.Name = jObject["Name"].Value<string>();
                target.Stereotype = (Stereotype)Enum.Parse(typeof(Stereotype), jObject["Stereotype"].Value<string>());
                target.TruncateType = (TruncateType)Enum.Parse(typeof(TruncateType), jObject["TruncateType"].Value<string>());
            }
            return target;
        }
        #endregion Methods
    }
}
