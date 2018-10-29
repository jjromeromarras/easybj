using Mecalux.ITSW.EasyBServices.Model.Data;
using Mecalux.ITSW.EasyBServices.Model.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mecalux.ITSW.EasyBServices.Controllers
{
    public class TraceManagerController: BaseController
    {
        //[UseSSL]
        [Route("web/settrace")]
        [System.Web.Http.HttpPost]
        public void SetTrace(HttpRequestMessage request)
        {
            try
            {
                TraceParameters model = JsonConvert.DeserializeObject<TraceParameters>(request.Content.ReadAsStringAsync().Result);
                TraceLogHelper.AddLog(typeof(TraceManagerController), model);
            }
            catch (Exception ex)
            {
                TraceParameters trace = new TraceParameters();
                trace.Msg = ex.Message;
                trace.Tracelevel = System.Web.Http.Tracing.TraceLevel.Fatal.ToString();
                TraceLogHelper.AddLog(typeof(TraceManagerController), trace);
            }
        }
    }
}
