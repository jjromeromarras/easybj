using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class GlobalSearchContainer: BaseEntity
    {
        #region Fields
        private List<GlobalSearch> globalSearchs;
        #endregion

        #region Constructors

        public GlobalSearchContainer()
            : base()
        {
            globalSearchs = new List<GlobalSearch>();
        }

        #endregion Constructors

        #region Properties

        private IEnumerable<GlobalSearch> GlobalSearchInternal
        {
            get
            {
                globalSearchs.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return globalSearchs;
            }
            set { globalSearchs = new List<GlobalSearch>(value); }
        }

        #endregion Properties
    }
}
