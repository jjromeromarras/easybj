using System;
using Mecalux.ITSW.Core.Abstraction;
using Mecalux.ITSW.Core.WinService;


namespace Mecalux.ITSW.EasyBServices
{
    /// <summary>
    /// Clase Servicio, controla la ejecución del servicio
    /// </summary>
    public class ServiceController : BaseServiceObject, IDisposable
    {
        #region Fields

        private readonly ILog logger;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ServiceController"/>
        /// </summary>
        public ServiceController()
        {
            logger = LogManager.GetLogger("ServiceController");
        }

        #endregion Constructor

        #region Protected methods

        /// <summary>
        /// Método principal de ejecución. Ejecuta un nuevo hilo del servicio <see cref="RequestServer"/>
        /// </summary>
        protected override void Execute()
        {
            using (LogManager.OpenNestedContext("Execute"))
            {
                try
                {
                    RequestServer server = new RequestServer("easybjs");
                }
                catch (Exception ex)
                {
                    logger.ErrorException(ex.Message, ex);
                }
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Método de finalizar ejecución. Este método maneja la finalización de los hilos esclavos
        /// </summary>
        protected override void Terminate()
        {
            using (LogManager.OpenNestedContext("Terminate"))
            {
                logger.Debug("Terminate Service Controller");
            }
        }
        #endregion Protected methods

        #region IDisposable

        /// <summary>
        /// Libera recursos no manejados y, opcionalmente, manejados
        /// </summary>
        /// <param name="disposing">true, para manejados y no manejados, false para solo no manejados </param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
            {
                disposing = true;
            }
        }

        /// <summary>
        /// Método que para el servicio
        /// </summary>
        ~ServiceController()
        {
            Dispose(false);
        }

        #endregion IDisposable
    }
}