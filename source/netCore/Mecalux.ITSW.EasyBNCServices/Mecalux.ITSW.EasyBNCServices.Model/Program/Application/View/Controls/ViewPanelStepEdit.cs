using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewPanelStepEdit: ViewPanelStep
    {
        #region Fields

        private List<ViewPanel> panels;

        #endregion Fields

        #region Constructors

        public ViewPanelStepEdit(string nameValue, string titleValue, string entityValue)
            : base(nameValue, titleValue, entityValue)
        {
            this.panels = new List<ViewPanel>();
        }

        public ViewPanelStepEdit(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewPanelStepEdit()
            : base()
        {
            this.panels = new List<ViewPanel>();
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<ViewPanel> PanelsInternal
        {
            get
            {
                panels.Sort((e1, e2) =>
                {
                    int result = e1.Sequence.CompareTo(e2.Sequence);
                    if (result == 0 && !string.IsNullOrEmpty(e1.Name))
                        result = e1.Name.CompareTo(e2.Name);
                    return result;
                });
                return panels;
            }
            set { panels = new List<ViewPanel>(value); }
        }
        #endregion
    }
}
