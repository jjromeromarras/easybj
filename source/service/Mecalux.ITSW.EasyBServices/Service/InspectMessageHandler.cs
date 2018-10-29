using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Mecalux.ITSW.Core.Abstraction;

namespace Mecalux.ITSW.EasyBServices
{
    /// <summary>
    /// Manejador de peticiones HTTP
    /// </summary>
    internal class InspectMessageHandler : DelegatingHandler
    {
        private readonly ILog logger;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InspectMessageHandler"/>
        /// </summary>
        public InspectMessageHandler()
        {
            this.logger = LogManager.GetLogger(nameof(InspectMessageHandler));
        }

        /// <summary>
        /// Método que maneja las peticiones HTTP <see cref="HttpRequestMessage"/>
        ///     *si la petición contiene alguno de los controladores que manejamos la tratamos
        ///     *si no no hacemos nada
        /// </summary>
        /// <param name="request">Petición HTTP</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Tarea con la petición HTTP de respuesta <see cref="HttpResponseMessage"/></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.RequestUri.LocalPath.ToLower().Contains("/web/"))
                {
                    string requestString = request.RequestUri.ToString();
                    if (!string.IsNullOrEmpty(requestString))
                    {
                        logger.Trace("WebApi Request String: {0}", requestString);
                    }
                    string content = request.Content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(content))
                    {
                        logger.Trace("WebApi Content Request: {0}", content);
                    }
                }
                else
                {
                    var response = request.CreateResponse<string>(HttpStatusCode.OK, "No data on this URL!!!!!");
                    return Task.FromResult<HttpResponseMessage>(response);
                }

                return base.SendAsync(request, cancellationToken);
            }
            catch (AggregateException ex)
            {
                logger.FatalException("Error sending result", ex);
                return null;
            }
        }
    }
}