using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class OrderedContractResolver : DefaultContractResolver
    {
        #region Fields

        private const int NotOrderedParticle = 500;

        #endregion Fields

        #region Methods

        // Protected Methods (1) 

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            List<JsonProperty> partialList = (List<JsonProperty>)base.CreateProperties(type, memberSerialization);
            partialList.Sort((x, y) =>
            {
                if (!x.Order.HasValue)
                    x.Order = NotOrderedParticle;
                if (!y.Order.HasValue)
                    y.Order = NotOrderedParticle;
                int result = x.Order.Value == y.Order.Value ? 0 : x.Order.Value < y.Order.Value ? -1 : 1;
                if (result == 0)
                    result = string.Compare(x.PropertyName, y.PropertyName);
                return result;
            });
            return partialList;
        }

        // Private Methods (1) 

        private string GetOrderKey(JsonProperty property)
        {
            return property.Order.Value.ToString("D3");
        }

        #endregion Methods
    }
}
