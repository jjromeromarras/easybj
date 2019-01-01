using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class FieldRecord: NameEntity, IInternalReference
    {
        #region Fields

        private int end;
        private string fieldType;
        private string format;
        private int length;
        private int start;

        #endregion Fields

        #region Constructors

        public FieldRecord(Guid id)
            : this()
        {
            Guid = id;
        }

        public FieldRecord()
            : base()
        {
            this.Format = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public int End
        {
            get => this.end;
            set => this.end = value;
        }

        public string FieldType
        {
            get => this.fieldType;
            set => this.fieldType = value;
        }

        public string Format
        {
            get => this.format;
            set => this.format = value;
        }

        public int Length
        {
            get => this.length; 
            set => this.length = value;
        }

        public int Start
        {
            get => this.start; 
            set => this.start = value;
        }

        #endregion Properties
    }
}
