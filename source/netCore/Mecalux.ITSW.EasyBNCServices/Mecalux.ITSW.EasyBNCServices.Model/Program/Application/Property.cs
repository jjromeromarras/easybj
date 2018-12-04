using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class Property: NameEntity
    {
        #region Properties
        public static readonly int DefaultDecimalLength = 12;
        public static readonly int DefaultDecimalPrecision = 5;


        private string columnName;
        private PropertyDataType dataType;
        private string defaultValue;
        private string help;
        private Boolean isActiveProperty;
        private Boolean isCustomField;
        private Boolean isDataWarehouse;
        private Boolean isIndex;
        private Boolean isPrimaryKey;
        private Boolean isReadOnly;
        private Boolean isRequiered;
        private Boolean isVisible;
        private int lenght;
        private int precision;
        private string title;
        private string validator;
        #endregion

        #region Constructors
        
        public Property(Guid id)
            : this()
        {
            Guid = id;
        }

        public Property()
            : base()
        {
            ColumnName =
            DefaultValue =
            Help = string.Empty;
        }

        #endregion Constructors

        #region Properties

        public string ColumnName
        {
            get
            {
                if (IsDataWarehouse)
                {
                    return Name;
                }
                else
                    return columnName;
            }
            set => columnName = value;
        }

        public PropertyDataType DataType
        {
            get { return dataType; }
            set
            {
                dataType = value;
            }
        }

        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }


        public string Help
        {
            get { return help; }
            set { help = value; }
        }

        public bool IsActiveProperty
        {
            get { return isActiveProperty; }
            set { isActiveProperty = value; }
        }

        public bool IsCustomField
        {
            get { return isCustomField; }
            set {  isCustomField = value; }
        }

        public bool IsDataWarehouse
        {
            get => isDataWarehouse;
            set => isDataWarehouse = value;
        }
            
        public bool IsIndex
        {
            get { return isIndex; }
            set {  isIndex = value; }
        }

        public bool IsPrimaryKey
        {
            get { return isPrimaryKey; }
            set { isPrimaryKey = value; }
        }

        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set { isReadOnly = value; }
        }

        public bool IsRequiered
        {
            get { return isRequiered; }
            set { isRequiered = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public int Lenght
        {
            get { return lenght; }
            set { lenght = value; }
        }

        public override string Name
        {
            get { return base.Name; }
            set
            {
                base.Name = value;
                if (IsDataWarehouse)
                    ColumnName = value;
            }
        }
        public int Precision
        {
            get { return precision; }
            set { precision =  value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Validator
        {
            get { return validator; }
            set { validator =  value; }
        }

        #endregion Properties
    }
}
