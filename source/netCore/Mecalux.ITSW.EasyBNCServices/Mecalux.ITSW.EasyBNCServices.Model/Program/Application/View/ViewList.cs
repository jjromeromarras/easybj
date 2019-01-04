using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewList: View
    {
        #region Properties
        private bool automaticRefresh;
        private int automaticRefreshInterval;
        private int rowLimit;
        private string sqlOrderBy;
        private string sqlWhere;
        private string sqlWhereFilterProperty;
        private bool useFilterProperty;
        private string filterProperty;
        private ViewGrid viewGrid;
        private ViewEdit detailView;
        private ViewEdit generalView;
        private string entity;
        private string notesEntity;
        private List<ActionViewList> actions;
        private string attachEntity;
        #endregion

        #region Constructors

        public ViewList(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewList()
            : base()
        {
            this.actions = new List<ActionViewList>();
            this.useFilterProperty = true;
            this.viewGrid = new ViewGrid();
            this.viewGrid.ParentEntity = this;
            this.generalView = new ViewEdit();
            this.generalView.ParentEntity = this;
            this.detailView = new ViewEdit();
            this.detailView.ParentEntity = this;
            SqlOrderBy =
            SqlWhere =
            SqlWhereFilterProperty = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public string AttachEntity
        {
            get { return attachEntity; }
            set { attachEntity = value; }
        }

        public bool AutomaticRefresh
        {
            get { return automaticRefresh; }
            set { automaticRefresh = value; }
        }

        public int AutomaticRefreshInterval
        {
            get { return automaticRefreshInterval; }
            set { automaticRefreshInterval = value; }
        }

        public ViewEdit DetailView
        {
            get { return detailView; }
            set { detailView = value; }
        }

        public string Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public string FilterProperty
        {
            get { return filterProperty; }
            set {  filterProperty = value; }
        }

        public ViewEdit GeneralView
        {
            get { return generalView; }
            set { generalView = value; }
        }

        public string NotesEntity
        {
            get { return notesEntity; }
            set { notesEntity = value; }
        }

        public int RowLimit
        {
            get { return rowLimit; }
            set { rowLimit= value; }
        }

        public string SqlOrderBy
        {
            get { return sqlOrderBy; }
            set { sqlOrderBy = value; }
        }

        public string SqlWhere
        {
            get { return sqlWhere; }
            set { sqlWhere = value; }
        }

        public string SqlWhereFilterProperty
        {
            get { return sqlWhereFilterProperty; }
            set { sqlWhereFilterProperty = value; }
        }
        public bool UseFilterProperty
        {
            get { return useFilterProperty; }
            set { useFilterProperty = value; }
        }

        public ViewGrid ViewGrid
        {
            get { return viewGrid; }
            set { viewGrid = value; }
        }

        public IEnumerable<ActionViewList> ActionsInternal
        {
            get
            {
                actions.Sort((e1, e2) =>
                {
                    int result = e1.Sequence.CompareTo(e2.Sequence);
                    if (result == 0)
                        result = e1.Action.Name.CompareTo(e2.Action.Name);
                    return result;
                });
                return actions;
            }
            set
            {
                actions = new List<ActionViewList>(value);
                actions.ForEach(a => a.ParentEntity = this);
            }
        }

        #endregion Properties

        #region Methods
        public void AddAction(ActionViewList element)
        {
            if (element == null)
                throw new ArgumentNullException("element", "Element can not be null");

            GenerateActionSequence(element, element.SideAction);
            this.actions.Add(element);
        }

        private void GenerateActionSequence(ActionViewList element, SideAction side)
        {
            if (element.Action != null && element.Action.Sequence == 0)
            {
                int maxSequence = 0;
                actions.ForEach(action =>
                {
                    if (action.SideAction == side)
                        if (action.Action.Sequence > maxSequence)
                            maxSequence = action.Action.Sequence;
                });

                if (element.Action != null)
                    element.Action.Sequence = maxSequence + 1;
            }
        }
        #endregion
    }
}
