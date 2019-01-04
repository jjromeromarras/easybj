using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class LinkJsonConverter: EasyBJsonConverter<Link>
    {
        #region Methods

        protected override Link Create(Type objectType)
        {
            return (Link)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Link obj = value as Link;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<Link>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyValue("ExpressionCode", obj.ExpressionCode, writer, serializer);
                    HelperJsonConverter.WritePropertyObjectsArray("LinkParametersInternal", typeof(List<LinkParameter>), obj.LinkParametersInternal, (objparams) =>
                    {
                            HelperJsonConverter.WritePropertyValue("Expression", objparams.Expression, writer, serializer);
                            HelperJsonConverter.WritePropertyValue("ViewParameterInternal", objparams.ViewParameterInternal, writer, serializer);
                    }, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("TargetViewInternal", obj.TargetViewInternal, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("TargetViewProperty", obj.TargetViewProperty, writer, serializer);

                }

            }

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jObject = JObject.Load(reader);
            Link target = default(Link);
            if (jObject != null)
            {
                target = Create(objectType);
                target.ExpressionCode = jObject["ExpressionCode"].Value<string>();
                target.TargetViewInternal = jObject["TargetViewInternal"].Value<string>();
                if (jObject["TargetViewProperty"].HasValues)
                    target.TargetViewProperty = jObject["TargetViewProperty"]["$ref"].Value<string>();

                if (jObject["LinkParametersInternal"]["$values"].HasValues)
                    foreach (var flchild in jObject["LinkParametersInternal"]["$values"])
                    {
                        LinkParameter f = new LinkParameter();
                        f.Expression = flchild["Expression"].Value<string>();
                        f.ViewParameterInternal = flchild["ViewParameterInternal"].Value<string>();
                        target.AddLinkParameter(f);
                    }
            }
            return target;
        }

        #endregion Methods
    }
}
