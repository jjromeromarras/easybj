using Newtonsoft.Json;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class Contact: NameEntity
    {
        #region Fields (3)

        private string email;
        private string phone;
        private string web;

        #endregion Fields

        #region Constructors (1)

        public Contact()
            : base()
        {
            Email =
            Phone =
            Web = string.Empty;
        }

        #endregion Constructors

        #region Properties (5)

        /// <summary>
        /// Contact's email
        /// </summary>
        public string Email
        {
            get => email;
            set => email = value;
        }

        /// <summary>
        /// Contact's name
        /// </summary>
        public override string Name
        {
            get => string.Empty;            
            set => base.Name = value; 
        }

        /// <summary>
        /// Contact's phone
        /// </summary>
        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        /// <summary>
        /// Contact's web
        /// </summary>
        public string Web
        {
            get => web; 
            set => web = value;
        }

        #endregion Properties
    }
}
