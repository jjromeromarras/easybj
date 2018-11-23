using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewGroup: CheckEntity
    {
        #region Constructors
                
        public ViewGroup(Guid id)
            : this()
        {
            Guid = id;
        }

        /// <summary>
        /// Default class constructor
        /// </summary>
        public ViewGroup()
            : base()
        {            
        }

        #endregion Constructors


    }
}
