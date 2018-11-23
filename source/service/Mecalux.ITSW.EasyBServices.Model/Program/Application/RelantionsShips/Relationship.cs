using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public abstract class Relationship: CheckEntity
    {
        #region Fields
        private string source;
        private string target;
        #endregion

        #region Constructors

        public Relationship(Guid id)
            : this()
        {
            Guid = id;
        }

        public Relationship()
            : base()
        {
            CheckStatus = CheckStatus.New;
        }

        #endregion Constructors

        #region Properties
        public String Source
        {
            get => source;
            set => source = value;
        }

        public String Target
        {
            get => target; 
            set => target = value;
        }

        #endregion Properties
    }
}
