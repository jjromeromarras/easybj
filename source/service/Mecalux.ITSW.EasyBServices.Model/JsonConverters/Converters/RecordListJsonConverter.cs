using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class RecordListJsonConverter : EasyBJsonConverter<RecordList>
    {
        #region Methods

        protected override RecordList Create(Type objectType)
        {
            return (RecordList)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            RecordList obj = value as RecordList;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<RecordList>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyValue("CheckStatus", obj.CheckStatus, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Description", obj.Description, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Files", obj.Files, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Guid", obj.Guid, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("Record", obj.Record, writer, serializer);
                }

            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            RecordList target = default(RecordList);
            if (jObject != null)
            {
                target = Create(objectType);
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.Files = jObject["Files"].Value<int>();
                target.Guid = Guid.Parse(jObject["Guid"].Value<string>());
                target.Name = jObject["Name"].Value<string>();
                target.Record = jObject["Record"]["$ref"].Value<string>();
            }
            return target;
        }
        #endregion Methods
    }
}
