using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewGrid: ViewFieldContainerControl
    {
        #region Fields
        public const string RowStyleDefaultReturnValue = "\n\nreturn GridCellStyle.None;";
        private int colCount;
        private List<ViewGridForeignFilter> foreignFilters;
        private int rowCount;
        private string rowStyle;

        #endregion Fields

        #region Constructors


        public ViewGrid(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewGrid()
            : base(string.Empty, null)
        {
            this.foreignFilters = new List<ViewGridForeignFilter>();
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

        public string RowStyle
        {
            get { return rowStyle; }
            set
            {
                if (string.IsNullOrEmpty(value?.Trim()))
                    rowStyle = RowStyleDefaultReturnValue;
                else
                    rowStyle = value;
            }
        }

        public IEnumerable<ViewGridForeignFilter> ForeignFiltersInternal
        {
            get
            {
                foreignFilters.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return foreignFilters;
            }
            set { foreignFilters = new List<ViewGridForeignFilter>(value); }
        }

        #endregion Properties

        #region Methods
        public void AddVF(ViewField element)
        {
            if (element == null)
                throw new ArgumentNullException("element", "Element can not be null");

            element.ParentEntity = this;

            this.AddViewfield(element);
        }
        #endregion
    }
}
