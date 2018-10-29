using Newtonsoft.Json;
using Owin;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Http;

namespace Mecalux.ITSW.EasyBServices
{
    /// <summary>
    /// Clase encargada de llamar a la configuración de los controladores
    /// </summary>
    public class OwinStartup
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="OwinStartup"/>
        /// </summary>
        public OwinStartup()
        {
        }

        /// <summary>
        /// Registra la configuración de los controladores, <see cref="WebApiConfig"/>
        /// </summary>
        /// <param name="app">Aplicación a configurar</param>
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }

    /// <summary>
    /// Configuración de los controladores
    /// </summary>
    public class WebApiConfig
    {
        /// <summary>
        /// Registra la configuración HTTP para los controladores, incluyendolos en el mapa de rutas y definiendo de que forma va a tratar los datos enviados
        /// </summary>
        /// <param name="config">Configuración HTTP, <see cref="HttpConfiguration"/>, para los controladores</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "web",
                routeTemplate: "web/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            List<Assembly> controllerAssemblies = new List<Assembly>();
            controllerAssemblies.Add(typeof(OwinStartup).Assembly);

            config.Services.Replace(typeof(System.Web.Http.Dispatcher.IAssembliesResolver), new CustomAssemblyResolver(controllerAssemblies));

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            config.MessageHandlers.Add(new InspectMessageHandler());
        }
    }
}
