using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.Model.Interfaz
{
    public interface IAvoidSerializedGuid: IBaseEntity
    {
        #region Data Members (4)

        IBaseEntity ParentSerializableEntity { get; }

        Guid ParentSerializableEntityVersionId { get; }

        string ReferencedName { get; }

        string SerializationParticle { get; }

        #endregion Data Members
    }
}
