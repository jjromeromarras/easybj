using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class RecordJsonConverter : EasyBJsonConverter<Record>
    {
        #region Methods

        protected override Record Create(Type objectType)
        {
            return (Record)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Record obj = value as Record;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj),writer, serializer);
                    HelperJsonConverter.WritePropertyType<Record> (writer, serializer, obj);
                    HelperJsonConverter.WritePropertyValue("AutoUpdateLength", obj.AutoUpdateLength, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("CheckStatus", obj.CheckStatus, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Description", obj.Description, writer, serializer);
                    HelperJsonConverter.WritePropertyObjectsArray("FieldRecordsInternal", typeof(List<FieldRecord>), obj.FieldRecordsInternal, (fieldrecord) =>
                    {
                        HelperJsonConverter.WritePropertyValue("End", fieldrecord.End, writer, serializer);
                        HelperJsonConverter.WritePropertyReference("FieldType", fieldrecord.FieldType, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Format", fieldrecord.Format, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Guid", fieldrecord.Guid, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Length", fieldrecord.Length, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Name", fieldrecord.Name, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Start", fieldrecord.Start, writer, serializer);

                    },writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Guid", obj.Guid, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("RecordType", obj.RecordType, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Separator", obj.Separator, writer, serializer);
                }

            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            Record target = default(Record);
            if (jObject != null)
            {
                target = Create(objectType);
                target.AutoUpdateLength = jObject["AutoUpdateLength"].Value<bool>();
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.Guid = Guid.Parse(jObject["Guid"].Value<string>());
                target.RecordType = (RecordType)Enum.Parse(typeof(RecordType), jObject["RecordType"].Value<string>());
                target.Separator = jObject["Separator"].Value<string>();
                target.Name = jObject["Name"].Value<string>();


                foreach (var flchild in jObject["FieldRecordsInternal"]["$values"])
                {
                    FieldRecord f = new FieldRecord();
                    f.Name = flchild["Name"].Value<string>();
                    f.End = flchild["End"].Value<int>();
                    f.Format = flchild["Format"].Value<string>();
                    f.Length = flchild["Length"].Value<int>();
                    f.Guid = Guid.Parse(flchild["Guid"].Value<string>());
                    f.Start = flchild["Start"].Value<int>();
                    f.FieldType = flchild["FieldType"]["$ref"].Value<string>();
                    target.AddFieldRecord(f);
                }

            }
            return target;
        }
        #endregion Methods
    }
}
