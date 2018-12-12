using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewEdit: View
    {
        #region Fields
        private int colCount;
        private string createCommand;
        private string createExpressionCode;
        private string entity;
        private string filterProperty;
        private bool openInNewWindow;
        private List<ViewPanel> panels;
        private string postBeforeRenderingCode;
        private string sqlWhere;
        private string updateCommand;
        private string updateExpressionCode;
        private bool useFilterProperty;
        #endregion

        #region Constructors

        public ViewEdit(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewEdit()
            : base()
        {
            panels = new List<ViewPanel>();
        }

        #endregion Constructors

        #region Properties

        public int ColCount
        {
            get
            {
                // ColCount for ViewEdit is always 1
                return 1;
            }
        }

        public string CreateCommand
        {
            get { return createCommand; }
            set { createCommand = value; }
        }

        public string CreateExpressionCode
        {
            get { return createExpressionCode; }
            set { createExpressionCode = value; }
        }

        public string Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public string FilterProperty
        {
            get { return filterProperty; }
            set { filterProperty = value; }
        }

        public bool OpenInNewWindow
        {
            get { return openInNewWindow; }
            set { openInNewWindow = value; }
        }
        public string PostBeforeRenderingCode
        {
            get { return postBeforeRenderingCode; }
            set { postBeforeRenderingCode = value; }
        }

        public string SqlWhere
        {
            get { return sqlWhere; }
            set { sqlWhere = value; }
        }

        public string UpdateCommand
        {
            get { return updateCommand; }
            set { updateCommand = value; }
        }

        public string UpdateExpressionCode
        {
            get { return updateExpressionCode; }
            set { updateExpressionCode = value; }
        }

        public bool UseFilterProperty
        {
            get { return useFilterProperty; }
            set { useFilterProperty = value; }
        }

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

        #endregion Properties

        #region Methods
        public void AddViewPanel(ViewPanel vp)
        {
            vp.ParentEntity = this;
            panels.Add(vp);
        }
        #endregion
    }
}
