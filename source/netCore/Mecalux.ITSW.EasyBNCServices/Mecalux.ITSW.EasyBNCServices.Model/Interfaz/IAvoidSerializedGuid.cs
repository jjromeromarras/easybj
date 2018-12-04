using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public interface IAvoidSerializedGuid: IBaseEntity
    {
        #region Data Members (4)

        CheckEntity ParentSerializableEntity { get; set; }

        Guid ParentSerializableEntityVersionId { get; }

        string ReferencedName { get; }

        string SerializationParticle { get; }

        #endregion Data Members
    }
}
