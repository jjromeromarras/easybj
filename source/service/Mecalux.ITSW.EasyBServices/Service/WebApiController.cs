using System;

namespace Mecalux.ITSW.EasyBServices
{
    /// <summary>
    /// Clase que gestiona un controlador
    /// </summary>
    public class WebApiController : IDisposable
    {
        private IDisposable requestServer = null;
        private string baseAddress = null;
        private bool isDisposed = false;

        /// <summary>
        /// Método que para la instancia de la clase <see cref="RequestServer"/> si no está parada ya
        /// </summary>
        public void Dispose()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                Stop();
            }
        }

        /// <summary>
        /// Método que inicializa la propiedad <see cref="baseAddress"/>
        /// </summary>
        /// <param name="baseAddress"></param>
        public void Initialize(string baseAddress)
        {
            this.baseAddress = baseAddress;
        }

        /// <summary>
        /// Método que inicializa una instancia de la clase <see cref="RequestServer"/>
        /// </summary>
        public void Start()
        {
            requestServer = new RequestServer(this.baseAddress);
        }

        /// <summary>
        /// Método que para la instancia de la clase <see cref="RequestServer"/>
        /// </summary>
        public void Stop()
        {
            if (requestServer != null)
            {
                requestServer.Dispose();
                requestServer = null;
            }
        }
    }
}