using System.Globalization;
using System.Threading;

namespace Mecalux.ITSW.EasyBServices.Base
{
    public class ContextConfig
    {
        #region Fields
        /// <summary>
        /// Indica el modo de funcionamiento
        /// </summary>
        private bool online;

        /// <summary>
        /// Idioma de la aplicaicón
        /// </summary>
        private CultureInfo language;
        private string languageCode;
        /// <summary>
        /// Porcentaje de repetición entre textos
        /// </summary>
        private decimal repetitionTextPercentage;

        /// <summary>
        /// Flag para marcar si se deben mostrar o no los elementos cuando se hace checkin de un elemento cuando no hay errores
        /// False: No se muestra si no hay errores. True: se muestra siempre
        /// </summary>
        private bool showAffectedEntities;

        /// <summary>
        /// Flag para marcar si se deben mostrar o no los errores en el grid de los elementos tageables.
        /// False: No se muestran. True: Se muestran
        /// </summary>
        private bool showErrorsInGrid;
        /// <summary>
        /// Flag para marcar si se deben abrir o no los elementos en las navegaciones.
        /// False: Se ejecuta la acción por defecto. True: solo se selecciona
        /// </summary>        
        private bool onlySelectOnNavigate;

        private string mruPath;
        private string lastFolderPath;
        private bool dontHideNavigationTree;
        private User currentUser;
        #endregion

        #region Constructors

        public ContextConfig()
            : base()
        {
            language = new CultureInfo(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            languageCode = language.TwoLetterISOLanguageName;
            MruPath = Context.GetDefaultPath();
            lastFolderPath = string.Empty;
            currentUser = new User();
        }

        #endregion Constructors

        #region Properties

        public User CurrentUser
        {
            get => currentUser; 
            set => currentUser = value;
        }

        public CultureInfo Language
        {
            get => language = new CultureInfo(languageCode);
            set
            {
                language = value;
                languageCode = language.TwoLetterISOLanguageName;
            }
        }

        public string LastFolderPath
        {
            get => lastFolderPath;
            set => lastFolderPath = value;
        }

        public string MruPath
        {
            get => mruPath;
            set => mruPath = value;
        }

        public bool Offline
        {
            get => !online;
            set => online = !value;
        }

        public bool Online
        {
            get => online;
            set => online = value;
        }

        /// <summary>
        /// Flag para marcar si se deben abrir o no los elementos en las navegaciones.
        /// False: Se ejecuta la acción por defecto. True: solo se selecciona
        /// </summary>
        public bool OnlySelectOnNavigate
        {
            get => onlySelectOnNavigate;
            set => onlySelectOnNavigate = value;
        }


        /// <summary>
        /// Porcentaje de repetición entre textos
        /// </summary>
        public decimal RepetitionTextPercentage
        {
            get => this.repetitionTextPercentage;
            set => this.repetitionTextPercentage = value;
        }

        /// <summary>
        /// Flag para marcar si se deben mostrar o no los elementos cuando se hace checkin de un elemento cuando no hay errores
        /// False: No se muestra si no hay errores. True: se muestra siempre
        /// </summary>
        public bool ShowAffectedEntities
        {
            get => showAffectedEntities;
            set => showAffectedEntities = value;
        }

        /// <summary>
        /// Flag para marcar si se deben mostrar o no los errores en el grid de los elementos tageables.
        /// False: No se muestran. True: Se muestran
        /// </summary>
        public bool ShowErrorsInGrid
        {
            get => showErrorsInGrid;
            set => showErrorsInGrid = value;
        }

        public bool DontHideNavigationTree
        {
            get => dontHideNavigationTree;
            set => dontHideNavigationTree = value;
        }

        #endregion Properties

        #region Methods
        internal void RebuildContext()
        {
            language = new CultureInfo(languageCode);
        }
        #endregion
    }
}
