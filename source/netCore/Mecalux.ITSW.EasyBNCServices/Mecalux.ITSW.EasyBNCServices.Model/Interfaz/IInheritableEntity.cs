﻿
namespace Mecalux.ITSW.EasyB.Model
{
    public interface IInheritableEntity: IBaseEntity
    {
        /// <summary>
        /// Tipo de herencia por la que la aplicacion actual obtuvo la referencia a esta entidad
        /// </summary>
        InheritanceType InheritanceType { get; }

        /// <summary>
        /// Aplicacion de la que se ha obtenido la referencia a esta entidad
        /// </summary>
        string SourceApplication { get; }
    }
}
