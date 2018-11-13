using System;

namespace Mecalux.ITSW.EasyBServices.Model.Interfaz
{
    public interface IOverridableEntity : IInheritableEntity
    {
        /// <summary>
        /// Si la entidad esta sobreescribiendo totalmente la version que existia en la aplicacion dependiente
        /// </summary>
        bool IsOverridden { get; }

        /// <summary>
        /// Id de la entidad que se esta sobreescribiendo
        /// </summary>
        Guid? OverriddenVersionId { get; }
    }
}
