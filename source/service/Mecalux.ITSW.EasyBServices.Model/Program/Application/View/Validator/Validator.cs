using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class Validator: CheckEntity
    {
        #region Fields
        private Guid text;
        #endregion

        #region Constructors

        protected Validator(string name, CheckStatus checkStatus = CheckStatus.New)
            : base()
        {
            Name = name;
            CheckStatus = checkStatus;
        }

        protected Validator()
            : base()
        {
            CheckStatus = CheckStatus.New;
        }

        #endregion Constructors

        #region Properties
        public Guid Text
        {
            get => text; 
            set => text = value;
        }
        #endregion
    }
}
