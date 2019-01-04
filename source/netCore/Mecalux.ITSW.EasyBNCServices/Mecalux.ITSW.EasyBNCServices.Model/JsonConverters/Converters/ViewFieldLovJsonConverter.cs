using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

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
            if (jObject != null)
            {
                target = Create(objectType);
                if (jObject["DependantProperty"].HasValues)
                    target.DependantProperty = jObject["DependantProperty"]["$ref"].Value<string>();
                if (jObject["DependantViewFieldLOV"].HasValues)
                    target.DependantViewFieldLOV = jObject["DependantViewFieldLOV"]["$ref"].Value<string>();
                if (jObject["DisplayProperty"].HasValues)
                    target.DisplayProperty= jObject["DisplayProperty"]["$ref"].Value<string>();
                if (jObject["EntityInternal"].HasValues)
                    target.EntityInternal = jObject["EntityInternal"]["$ref"].Value<string>();

                if (jObject["InLineLink"].HasValues)
                {
                    Link obj = jObject["InLineLink"].ToObject<Link>(serializer);
                    if (obj != null)
                        target.AddInLineLink(obj);
                }

                if (jObject["LovsInternal"]["$values"].HasValues)
                {
                    foreach (var flchild in jObject["LovsInternal"]["$values"])
                    {
                        Lov obj = flchild.ToObject<Lov>(serializer);
                        if (obj != null)
                            target.AddLov(obj);
                    }
                }

                target.OrderLovType = (OrderLovType)Enum.Parse(typeof(OrderLovType), jObject["OrderLovType"].Value<string>());
                target.RowLimit = jObject["RowLimit"].Value<int>();

                if (jObject["ShowPropertiesInternal"]["$values"].HasValues)
                {
                    foreach (var flchild in jObject["ShowPropertiesInternal"]["$values"])
                    {
                        var obj = flchild["$ref"].Value<string>();
                        if (obj != null)
                            target.ShowPropertiesInternal.Add(Guid.Parse(obj));
                    }
                }

                target.SqlOrderBy = jObject["SqlOrderBy"].Value<string>();
                target.SqlWhere = jObject["SqlWhere"].Value<string>();
                target.SqlWhere = jObject["SqlWhere"].Value<string>();

                if (jObject["ValueProperty"].HasValues)
                    target.ValueProperty = jObject["ValueProperty"]["$ref"].Value<string>();
            }
            return target;
        }

        #endregion Methods
    }
}
