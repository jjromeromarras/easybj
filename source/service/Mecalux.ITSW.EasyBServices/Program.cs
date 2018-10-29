using System;
using System.Threading.Tasks;
using Mecalux.ITSW.Core.Abstraction;
using Mecalux.ITSW.Core.WinService;


namespace Mecalux.ITSW.EasyBServices
{
    /// <summary>
    /// Clase que despliega el proyecto
    /// </summary>
    public static class Program
    {
        private const string SERVICE_DISPLAY_NAME = "EasyB JS Service";

        private const string SERVICE_DESCRIPTION = "EasybB JS Service@Mecalux Software Solution";
        private const string SERVICE_NAME = "EasyB JS Service";
        private const string SERVICE_OBJECT_NAME = "EasyBJSThread";

        
        /// <summary>
        /// Main del servicio, carga la base de datos en el objeto contexto e inicializa el servicio
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            InitializeServive();
            StaticService.Initialize(args, SERVICE_NAME, SERVICE_DISPLAY_NAME, SERVICE_DESCRIPTION, SERVICE_OBJECT_NAME);
            StaticService.ManageService();
        }

        /// <summary>
        /// Método que captura las excepciones que puedan suceder en los hilos de las tareas
        /// </summary>
        private static void InitializeServive()
        {
            TaskScheduler.UnobservedTaskException +=
                (object sender, UnobservedTaskExceptionEventArgs eventArgs) =>
                {
                    eventArgs.SetObserved();
                    ((AggregateException)eventArgs.Exception).Handle(ex =>
                    {
                        ILog logger = LogManager.GetLogger("HLLSService");
                        logger.ErrorException("Error in task. See inner exception error for more details.", ex);
                        return true;
                    });
                };
        }
    }
}
