using Newtonsoft.Json;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class AdJobFrequency : BaseEntity
    {
        #region Fields (4)

        private int days;
        private int hours;
        private int minutes;
        private int seconds;

        #endregion Fields

        #region Properties (4)

        public int Days
        {
            get => days;
            set => days = value;
        }

        public int Hours
        {
            get => hours;
            set => hours = value;
        }

        public int Minutes
        {
            get => minutes;
            set => minutes = value;
        }

        public int Seconds
        {
            get => seconds;
            set => seconds = value;
        }

        #endregion Properties
    }
}
