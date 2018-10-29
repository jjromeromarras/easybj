using Mecalux.ITSW.Core.Abstraction;
using System.Web.Http;

namespace Mecalux.ITSW.EasyBServices.Controllers
{
    public class BaseController: ApiController
    {
        #region Fields
        private ILog log;
        #endregion

        #region Properties
        public ILog Log { get { return log; } }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseController()
        {
            this.log = LogManager.GetLogger(typeof(BaseController));
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }
    }
}
