using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionLinkAssistant: Action
    {
        #region Fields

        private bool? isSingleExecution;
        private Link link;

        #endregion Fields

        #region Constructors

        public ActionLinkAssistant(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionLinkAssistant()
            : base()
        {
            this.link = new Link();
            this.link.ParentSerializableEntity= this;
        }

        #endregion Constructors

        #region Properties

        public bool? IsSingleExecution
        {
            get { return isSingleExecution; }
            set { isSingleExecution = value; }
        }

        public Link Link
        {
            get { return link; }
            set { link = value; }
        }

        #endregion Properties
    }
}
