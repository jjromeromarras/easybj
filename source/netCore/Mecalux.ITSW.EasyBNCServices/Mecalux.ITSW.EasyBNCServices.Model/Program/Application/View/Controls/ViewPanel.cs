using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewPanel: ViewFieldContainerControl
    {
        #region Fields

        private int colCount;
        private List<ViewControl> controls;
        private int rowCount;

        #endregion Fields

        #region Constructors

        public ViewPanel(string nameValue, string titleValue)
            : base(nameValue, titleValue)
        {
            this.controls = new List<ViewControl>();
        }

        public ViewPanel(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewPanel()
            : base(string.Empty, null)
        {
            this.controls = new List<ViewControl>();
        }

        #endregion Constructors

        #region Properties
        public int ColCount
        {
            get { return colCount; }
            set { colCount = value; }
        }

        public int RowCount
        {
            get { return rowCount; }
            set { rowCount = value; }
        }

        public IEnumerable<ViewControl> ControlsInternal
        {
            get
            {
                controls.Sort((e1, e2) =>
                {
                    int result = e1.Sequence.CompareTo(e2.Sequence);
                    if (result == 0 && !string.IsNullOrEmpty(e1.Name))
                        result = e1.Name.CompareTo(e2.Name);
                    return result;
                });
                return controls;
            }
            set { controls = new List<ViewControl>(value); }
        }
        #endregion

        #region Methods
        public void Add(ViewControl element)
        {
            if (element == null)
                throw new ArgumentNullException("element", "Element can not be null");
            element.ParentEntity = this.ParentEntity;
        }
        #endregion
    }
}
