namespace Mecalux.ITSW.EasyB.Model
{
    public abstract class NameEntity: BaseEntity
    {
        #region Fields
        private string name;
        #endregion

        #region Constructor
        public NameEntity()
            :base() { }
        #endregion

        #region Properties
        public virtual string Name
        {
            get => name;
            set => name = value;
        }
        #endregion
    }
}
