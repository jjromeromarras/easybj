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
            if (jObject != null)
            {
                target = Create(objectType);
                if (jObject["DisplayValue"].HasValues)
                    target.DisplayValue = jObject["DisplayValue"]["$ref"].Value<string>(); 
                target.Value = jObject["Value"].Value<string>();
            }
            return target;
        }

        #endregion Methods
    }
}
