using Mecalux.ITSW.EasyBServices.Model.Interfaz;
using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public abstract class BaseEntity: IBaseEntity
    {
        #region Fields
       
        private DateTime createDate;
        private string createdBy;
        private Guid guid;
        private string updatedBy;
        #endregion Fields

        #region Constructor
        public BaseEntity()
        {
            guid = Guid.NewGuid();
            createDate = DateTime.Now;
        }
        #endregion

        #region Properties     

        [JsonIgnore]
        public DateTime CreateDate
        {
            get => createDate;
            set => createDate = value;
        }

        [JsonIgnore]
        public string CreatedBy
        {
            get => createdBy;
            set => createdBy = value;
        }

        public virtual Guid Guid
        {
            get => guid;
            set => guid = value;
        }

        [JsonIgnore]
        public string UpdatedBy
        {
            set => updatedBy = value;
            get => updatedBy;
        }
        #endregion

    }
}
