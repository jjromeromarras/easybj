using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewPageControl: ViewControl
    {
        #region Fields

        private List<ViewPanelPage> pages;

        #endregion Fields

        #region Constructors


        public ViewPageControl(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewPageControl()
            : base(string.Empty, null)
        {
            this.pages = new List<ViewPanelPage>();
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<ViewPanelPage> PagesInternal
        {
            get
            {
                pages.Sort((e1, e2) =>
                {
                    int result = e1.Sequence.CompareTo(e2.Sequence);
                    if (result == 0 && !string.IsNullOrEmpty(e1.Name))
                        result = e1.Name.CompareTo(e2.Name);
                    return result;
                });
                return pages;
            }
            set { pages = new List<ViewPanelPage>(value); }
        }
        #endregion

        #region Methods
        public void AddPanelPage(ViewPanelPage vp)
        {
            vp.ParentEntity = this;
            pages.Add(vp);
        }
        #endregion
    }
}
