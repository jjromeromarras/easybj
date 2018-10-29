using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace Mecalux.ITSW.EasyBServices
{
    /// <summary>
    /// Resolvedor de ensamblados para los controladores del WebAPI
    /// </summary>
    public class CustomAssemblyResolver : DefaultAssembliesResolver
    {
        private readonly List<Assembly> controllerAssemblies;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CustomAssemblyResolver"/>
        /// </summary>
        public CustomAssemblyResolver()
        {
            this.controllerAssemblies = new List<Assembly>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CustomAssemblyResolver"/>
        /// </summary>
        /// <param name="assemblies">Lista de ensamblados</param>
        public CustomAssemblyResolver(IEnumerable<Assembly> assemblies)
            : this()
        {
            this.controllerAssemblies.AddRange(assemblies);
        }

        /// <summary>
        /// Devuelve una lista de ensamblados disponibles para la aplicación
        /// </summary>
        /// <returns>Lista de ensamblados</returns>
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
            controllerAssemblies.ForEach(a => baseAssemblies.Add(a));

            return assemblies;
        }
    }
}
