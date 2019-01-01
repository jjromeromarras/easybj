using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class EventJsonConverter : EasyBJsonConverter<Event>
    {
        #region Methods

        protected override Event Create(Type objectType)
        {
            return (Event)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Event obj = value as Event;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<Event>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyValue("CheckStatus", obj.CheckStatus, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Description", obj.Description, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("InternalName", obj.InternalName, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("IsPublic", obj.IsPublic, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyObjectsArray("PropertiesInternal", typeof(List<EventProperty>), obj.PropertiesInternal, (objchild) =>
                    {
                        HelperJsonConverter.WritePropertyValue("DataType", objchild.DataType, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Description", objchild.Description, writer, serializer);
                        HelperJsonConverter.WritePropertyValue("Name", objchild.Name, writer, serializer);
                    }, writer, serializer);

                    HelperJsonConverter.WritePropertyValue("VersionId", obj.VersionId, writer, serializer);
                }

            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            Event target = default(Event);
            if (jObject != null)
            {
                target = Create(objectType);
                target.CheckStatus = (CheckStatus)Enum.Parse(typeof(CheckStatus), jObject["CheckStatus"].Value<string>());
                target.Description = jObject["Description"].Value<string>();
                target.VersionId = Guid.Parse(jObject["VersionId"].Value<string>());
                target.Guid = target.VersionId;
                target.InternalName = jObject["InternalName"].Value<string>();
                target.IsPublic = jObject["IsPublic"].Value<bool>();
                target.Name = jObject["Name"].Value<string>();
                
                if (jObject["PropertiesInternal"]["$values"].HasValues)
                {
                    foreach (var flchild in jObject["PropertiesInternal"]["$values"])
                    {
                        EventProperty f = new EventProperty();
                        f.Name = flchild["Name"].Value<string>();
                        f.Description = flchild["Description"].Value<string>();
                        f.DataType = (EventPropertyDataType)Enum.Parse(typeof(EventPropertyDataType), flchild["DataType"].Value<string>());
                        target.AddEventProperty(f);
                    }
                }

            }

            return target;
        }
        
        #endregion Methods
    }
}
