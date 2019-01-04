using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewGridJsonConverter : EasyBJsonConverter<ViewGrid>
    {
        protected override ViewGrid Create(Type objectType)
        {
            return (ViewGrid)Activator.CreateInstance(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            ViewGrid obj = value as ViewGrid;
            if (obj != null)
            {
                writer.WriteStartObject();
                {
                    HelperJsonConverter.WritePropertyValue("$id", HelperJsonConverter.GetReferenceInternal(obj), writer, serializer);
                    HelperJsonConverter.WritePropertyType<ViewGrid>(writer, serializer, obj);
                    HelperJsonConverter.WritePropertyValue("ColCount", obj.ColCount, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("ColSpan", obj.ColSpan, writer, serializer);
                    HelperJsonConverter.WritePropertyObjectsArray("FieldsInternal", typeof(List<ViewField>), obj.FieldsInternal, (objchild) =>
                    {
                        serializer.Serialize(writer, objchild);
                    }, writer, serializer);

                    //ForeignFiltersInternal

                    HelperJsonConverter.WritePropertyValue("Name", obj.Name, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("RowCount", obj.RowCount, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("RowSpan", obj.RowSpan, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("Sequence", obj.Sequence, writer, serializer);
                    HelperJsonConverter.WritePropertyReference("Title", obj.Title, writer, serializer);
                    HelperJsonConverter.WritePropertyValue("VisibilityCondition", obj.VisibilityCondition, writer, serializer);

                }
            }
        }
    }
}
