namespace Mecalux.ITSW.EasyBServices.Model
{
    public abstract class NameEntity: BaseEntity
    {
        #region Fields
        private string name;
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
