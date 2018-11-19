using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class FieldType: CheckEntity, ICommonEntity
    {
        #region Fields
        private CheckDigit checkDigit;
        private string description;
        private FillMode fillMode;
        private string inputMask;
        private int length;
        private Stereotype stereotype;
        private TruncateType truncateType;
        private Guid entityStereotypeInternal;     
        private EditionLengthMode editionLengthMode;

        private DateTime? updateDate;
        #endregion

        #region Constructors


        public FieldType(Guid id)
            : this()
        {
            Guid = id;
        }

        /// <summary>
        /// Default class constructor
        /// </summary>
        public FieldType()
            : base()
        {
            description = string.Empty;
            inputMask = string.Empty;
            stereotype = Stereotype.String;
            CheckStatus = CheckStatus.New;
            this.SetCreateData();
            CreatedBy =
            LockedBy =
            UpdatedBy = string.Empty;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The field type code accuracy
        /// </summary>
        public CheckDigit CheckDigit
        {
            get => checkDigit; 
            set => checkDigit = value;
        }

        /// <summary>
        /// The field type description
        /// </summary>
        public string Description
        {
            get => description; 
            set => description = value;
        }

        /// <summary>
        /// The field type length mode
        /// </summary>
        public EditionLengthMode EditionLengthMode
        {
            get => editionLengthMode; 
            set => editionLengthMode = value;
        }

        /// <summary>
        /// The field type fill mode when the length of the input data is minor than the defined length
        /// </summary>
        public FillMode FillMode
        {
            get => fillMode; 
            set => fillMode = value;
        }

        /// <summary>
        /// The field type format mask
        /// </summary>
        public string InputMask
        {
            get => inputMask; 
            set =>  inputMask = value;
        }

        /// <summary>
        /// The field type length
        /// </summary>
        public int Length
        {
            get => length; 
            set => length = value;
        }

        public Stereotype Stereotype
        {
            get => stereotype; 
            set => stereotype = value;
        }

        /// <summary>
        /// The field type truncate mode
        /// </summary>
        public TruncateType TruncateType
        {
            get => truncateType; 
            set => truncateType = value;
        }

        public Guid EntityStereotypeInternal
        {
            get => entityStereotypeInternal; 
            set => entityStereotypeInternal = value; 
        }

        [JsonIgnore]
        public DateTime? UpdateDate {
            get => updateDate;
            set => updateDate = value;
        }

        #endregion Properties
    }
}
