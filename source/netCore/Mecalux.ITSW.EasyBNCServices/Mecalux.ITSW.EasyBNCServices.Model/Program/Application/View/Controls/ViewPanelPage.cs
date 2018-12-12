using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewPanelPage: ViewPanel
    {
        #region Fields

        private bool defaultPage;
        private int pageNumber;

        #endregion Fields

        #region Constructors

        public ViewPanelPage(string nameValue, string titleValue)
            : base(nameValue, titleValue)
        {
        }

        public ViewPanelPage(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewPanelPage()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public bool DefaultPage
        {
            get { return defaultPage; }
            set { defaultPage = value; }
        }

        public int PageNumber
        {
            get { return pageNumber; }
            set { pageNumber = value; }
        }

        #endregion Properties
    }
}
