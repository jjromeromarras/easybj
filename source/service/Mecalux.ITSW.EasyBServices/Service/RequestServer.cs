using Mecalux.ITSW.Core.Abstraction;
using Microsoft.Owin.Hosting;
using System;

namespace Mecalux.ITSW.EasyBServices
{
    /// <summary>
    /// Clase que inicializa los controladores y los configura
    /// </summary>
    public class RequestServer : IDisposable
    {
        private IDisposable httpServiceHost = null;
        private string baseAddress = null;
        private readonly ILog logger = LogManager.GetLogger("WebApiController");
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RequestServer"/>
        /// </summary>
        /// <param name="baseAddress">String que indica la dirección en la que se van a encontrar los controladores</param>
        public RequestServer(string baseAddress)
        {
            this.baseAddress = string.Format("http://*:5800/{0},https://*:5801/{0}", baseAddress);
            httpServiceHost = StartHttp();
        }

        private bool disposed = false;

        /// <summary>
        /// Método que para la instancia de la clase <see cref="OwinStartup"/> si no está parada ya
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                httpServiceHost.Dispose();
                disposed = true;
            }
        }

        /// <summary>
        /// Método que inicia la clase <see cref="OwinStartup"/> con las opciones 
        /// </summary>
        /// <returns></returns>
        private IDisposable StartHttp()
        {

            using (LogManager.OpenNestedContext("StartHttp"))
            {
                var options = new StartOptions();
                string[] uris = baseAddress.Split(',');

                foreach (string uri in uris)
                    options.Urls.Add(uri.Trim());

                IDisposable webApp = Microsoft.Owin.Hosting.WebApp.Start<OwinStartup>(options);
                logger.Info("WebApi hosted in : {0}", string.Join(", ", options.Urls));
                System.Console.WriteLine("WebApi hosted in : {0}", string.Join(", ", options.Urls));

                return webApp;
            }
        }
    }
}
