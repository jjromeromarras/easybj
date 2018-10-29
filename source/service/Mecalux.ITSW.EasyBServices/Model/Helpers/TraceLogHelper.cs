using Mecalux.ITSW.Core.Abstraction;
using Mecalux.ITSW.EasyBServices.Model.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;

namespace Mecalux.ITSW.EasyBServices.Model.Helpers
{
    public static class TraceLogHelper
    {
        /// <summary>
        /// Diccionario con todos los loggers según el tipo de las clases
        /// </summary>
        private static ConcurrentDictionary<Type, ILog> loggers;

        /// <summary>
        /// Añade un registro a la pila de la traza
        /// </summary>
        /// <param name="text"></param>
        /// <param name="entityCode"></param>
        /// <param name="action"></param>

        public static void AddLog(Type typeClass, TraceParameters trace)
        {
            ILog logger = GetLogger(typeClass);
            try
            {
                TraceLevel level = (TraceLevel)Enum.Parse(typeof(TraceLevel), trace.Tracelevel);
                string text = trace.Msg;
                if (string.IsNullOrEmpty(trace.Stack))
                {
                    text = trace.Msg;
                }
                else
                {
                    text = trace.Msg + System.Environment.NewLine + trace.Stack;
                }

                switch (level)
                {
                    case TraceLevel.Error:
                        logger.Error(text);
                        break;

                    case TraceLevel.Fatal:
                        logger.Fatal(text);
                        break;

                    case TraceLevel.Info:
                        logger.Info(text);
                        break;

                    case TraceLevel.Debug:
                        logger.Debug(text);
                        break;

                    case TraceLevel.Warn:
                        logger.Warn(text);
                        break;

                    default:
                        logger.Trace(text);
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Fatal("Exception try to add log Message: {0}" + ex.Message.ToString());
                logger.Fatal("Exception try to add log StackTrace: {0}" + ex.StackTrace.ToString());
            }
        }

        /// <summary>
        /// Método para obtener el tipo de logger usado para ese tipo de clase
        /// </summary>
        /// <param name="typeClass">Tipo de clase del que se quiere obtener un logger</param>
        /// <returns>Logger usado para un tipo de clase</returns>
        private static ILog GetLogger(Type typeClass)
        {
            if (loggers == null)
                loggers = new ConcurrentDictionary<Type, ILog>();

            if (typeClass == null)
                typeClass = typeof(TraceLogHelper);

            ILog logger = null;

            if (loggers.ContainsKey(typeClass))
                logger = loggers[typeClass];
            else
            {
                logger = LogManager.GetLogger(typeClass);
                loggers.TryAdd(typeClass, logger);
            }

            return logger;
        }
    }
}
