using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public interface ICommonEntity : IBaseEntity
    {
        #region Data Members (4)

        DateTime CreateDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdateDate { get; set; }

        string UpdatedBy { get; set; }

        #endregion Data Members
    }
}
