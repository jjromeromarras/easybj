using System;

namespace Mecalux.ITSW.EasyBServices.Model.Interfaz
{
    /// <summary>
    /// Interfaz implementado por aquellas entidades que pueden ser sobreescritas parcialmente entre aplicaciones dependientes
    /// </summary>
    public interface IPartiallyOverridableEntity : IInheritableEntity
    {
        #region Properties

        /// <summary>
        /// Indica si está parcialmente sobreecrito
        /// </summary>
        bool IsPartiallyOverridden { get; }

        /// <summary>
        /// VersionId del elemento que se sobreescribe
        /// Si es null no sobreescribe a nadie
        /// </summary>
        Guid? OverriddenVersionId { get; set; }

        /// <summary>
        /// En las $<see cref="IsVirtualEntity"/> indica el elemento del que sacar los datos comunes
        /// </summary>
        IPartiallyOverridableEntity SourceEntity { set; get; }

        
        #endregion Properties
    }
}
