using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionCustom: Action
    {
        #region Constructors

        public ActionCustom(string nameValue)
            : base(nameValue)
        {
        }

        public ActionCustom(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionCustom()
            : base()
        {
        }

        #endregion Constructors
    }
}
