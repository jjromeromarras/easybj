using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionAudit: Action
    {
        #region Constructors
        
        public ActionAudit(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionAudit()
            : base()
        {
            InitializeDefaultActionAudit();
        }

        #endregion Constructors

        #region Methods

        // Private Methods (1) 

        private void InitializeDefaultActionAudit()
        {
            this.VisibleMultiRowSelected = false;
            this.VisibleNoRowSelected = false;
            this.VisibleOneRowSelected = true;
        }

        #endregion Methods
    }
}
