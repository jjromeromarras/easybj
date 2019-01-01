using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class NumericValidator: Validator
    {
        #region Fields

        private double maxvalue;
        private double minvalue;
        private int precision;

        #endregion Fields

        #region Constructors

        public NumericValidator(string name, double max, double min, int precision)
            : base(name)
        {
            MaxValue = max;
            MinValue = min;
            Precision = precision;
        }

        public NumericValidator(Guid id)
            : this()
        {
            Guid = id;
        }

        public NumericValidator()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public double MaxValue
        {
            get =>  maxvalue;
            set => maxvalue = value;
        }

        public double MinValue
        {
            get => minvalue; 
            set => minvalue = value;
        }

        public int Precision
        {
            get => precision;
            set => precision = value;
        }

        #endregion Properties
    }
}
