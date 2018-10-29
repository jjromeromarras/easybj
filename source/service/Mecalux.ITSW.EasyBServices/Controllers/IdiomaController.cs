using Mecalux.ITSW.Core.Abstraction;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Mecalux.ITSW.EasyBServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class IdiomaController: ApiController
    {
        private readonly ILog logger = LogManager.GetLogger("IdiomaController");

        [HttpGet]
        [ResponseType(typeof(Boolean))]
        [Route("web/allidiomas")]
        public Boolean GetIdioma()
        {
            using (LogManager.OpenNestedContext("GetIdiomas"))
            {
                try
                {
                  
                    return true;
                }
                catch (Exception ex)
                {
                    logger.DebugException(ex.Message, ex);
                    return false;
                }
            }
        }
    }
}
