using Mecalux.ITSW.EasyBService.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class Organization: BaseEntity
    {
        #region Fields
        private List<AdJob> adJobs;        
        //private Image logo;
        private List<MenuItem> menuItems;
        private List<Resource> menuResorce;

        #endregion
    }
}
