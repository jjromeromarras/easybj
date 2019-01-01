namespace Mecalux.ITSW.EasyBCoreServices.Base
{
    public class User
    {
        #region Fields
        private string domain;
        private bool isSingleSingOn;
        private string password;
        private string name;
        #endregion

        #region Constructors

        public User()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Dominio al que pertenece el usaurio.
        /// Usao en SingleSingOn
        /// </summary>
        public string Domain
        {
            get { return this.domain; }
            set { this.domain = value; }
        }

        /// <summary>
        /// Flag para indicar que el usuario esta o se va validar por SingleSingOn (LDAP).
        /// True: Se usa SingleSingOn (LDAP). False: Se usa usuario y password
        /// </summary>
        public bool IsSingleSingOn
        {
            get { return this.isSingleSingOn; }
            set { this.isSingleSingOn = value; }
        }

        
        public string Name
        {
            get
            {
                string result;
                if (this.IsSingleSingOn)
                    result = string.Format(@"{0}\{1}", this.Domain, name);
                else
                    result = name;
                return result;
            }
            set { name = value; }
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        #endregion Properties
    }
}
