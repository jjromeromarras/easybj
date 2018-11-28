using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionViewList: CheckEntity
    {
        #region Fields

        private Action action;
        private ActionViewList internalParentTreeElement;
        private SideAction sideAction;

        #endregion Fields

        #region Constructors

        public ActionViewList(Action actionValue, SideAction sideActionValue)
            : this()
        {

            this.action = actionValue;
            this.sideAction = sideActionValue;
        }

        public ActionViewList(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionViewList()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public Action Action
        {
            get { return action; }
            set { action = value; }
        }

        [Category("Hidden"), Browsable(false)]
        [JsonIgnore]
        public IEnumerable<string> EquivalentPropertyNames
        {
            get
            {
                yield return "SideAction";
                yield return "Sequence";
                yield return "Action";
            }
        }

        [Category("Hidden"), Browsable(false)]
        [JsonIgnore]
        public string FullSequence
        {
            get { return this.BuildFullSequence(); }
        }

        [Browsable(true), Category("Internal"), Unique]
        [JsonIgnore]
        public override Guid Guid
        {
            get
            {
                this.GenerateGuid();
                return base.Guid;
            }
            set { base.Guid = value; }
        }

        [Category("Hidden"), Browsable(false)]
        [JsonIgnore]
        public bool IsEditable
        {
            get
            {
                return ParentRootView.IsEditable;
            }
        }

        [Category("Hidden"), Browsable(false)]
        [JsonIgnore]
        public bool IsEquivalentRoot
        {
            get { return true; }
        }

        [Browsable(false)]
        [JsonIgnore]
        public IRootElement ParentRoot
        {
            get
            {
                Application result = null;
                View view = this.ParentEntity as View;
                if (view != null)
                    result = view.ParentRoot as Application;

                return result;
            }
        }

        /// <summary>
        /// Property obtener la vista padre que contiene la accion
        /// </summary>
        [Browsable(false)]
        [JsonIgnore]
        public View ParentRootView
        {
            get
            {
                IBaseEntity parentTemp = this.ParentEntity;
                View parentViewTemp = this.ParentEntity as View;

                while (parentViewTemp == null && parentTemp != null && parentTemp != parentTemp.ParentEntity)
                {
                    parentTemp = parentTemp.ParentEntity;
                    parentViewTemp = parentTemp as View;
                }

                return parentViewTemp;
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public IBaseEntity ParentSerializableEntity
        {
            get { return this.ParentRootView; }
        }

        [JsonIgnore]
        [Browsable(false)]
        public Guid ParentSerializableEntityVersionId
        {
            get { return this.ParentRootView.VersionId; }
        }

        [Browsable(false), AvoidBuildFrom(AvoidSet = true)]
        [JsonIgnore]
        public ITreeMovableDestinyItem ParentTreeElement
        {
            get { return internalParentTreeElement; }
            set
            {
                ActionViewList avl = value as ActionViewList;
                this.SideAction = avl.SideAction;
                RefreshTreeEntity();
                SetParentOnLoad(avl.GetTreeEntity().Entity as ActionViewList);
                if (this.treeEntityCached != null)
                    this.treeEntityCached.ParentTreeId = avl.GetTreeEntity().TreeId;
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        public ViewList ParentViewList
        {
            get { return this.ParentEntity as ViewList; }
        }

        [JsonIgnore]
        [Browsable(false)]
        public string ReferencedName
        {
            get
            {
                string result = string.Empty;
                if (!(this.ParentEntity is View))
                {
                    IAvoidSerializedGuid avoidParent = this.ParentEntity as IAvoidSerializedGuid;
                    if (avoidParent != null)
                        result = avoidParent.ReferencedName + GuidReferenceResolver.Separator;
                }
                if (this.Action != null)
                    result += this.Action.Name;
                return result;
            }
        }

        [JsonIgnore]
        public IBaseEntity SelectableEntity
        {
            get { return this.Action; }
        }

        [JsonIgnore, BindedEditor(BindedEditorKind.SpinReadOnlyEdit)]
        public int Sequence
        {
            get
            {
                int i = 1;
                if (action != null)
                    i = action.Sequence;
                return i;
            }
            set
            {
                if (action != null)
                    action.Sequence = value;

                RefreshTreeEntity();
            }
        }

        [JsonIgnore]
        [Browsable(false)]
        public string SerializationParticle
        {
            get { return GuidReferenceResolver.ActionViewListParticle; }
        }

        [Category("Data"), Browsable(true), Obligatory, JsonIgnore]
        public SideAction SideAction
        {
            get { return sideAction; }
            set
            {
                CalculateSequence(value);
                SetValue(ref sideAction, value);
            }
        }

        [JsonProperty, AvoidBuildFrom(AvoidSet = true)]
        private SideAction SideActionInternal
        {
            get { return sideAction; }
            set { sideAction = value; }
        }

        #endregion Properties
    }
}
