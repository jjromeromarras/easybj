using System.Collections.Generic;
using System.Linq;

namespace Mecalux.ITSW.EasyB.Model
{
    public static class NameEntityHelper
    {
        public static string CalculateName(IEnumerable<NameEntity> collection, string name)
        {
            int i = 1;
            string currKey = name;
            List<NameEntity> list = collection.ToList();
            while (list.Exists(r => r.Name == currKey))
            {
                currKey = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}{1}", name, i);
                i++;
            }

            return currKey;
        }

    }
}
