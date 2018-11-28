using System;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ActionAttachNotes: Action
    {
        #region Fields
        private string addAttachCommand;
        private string addNoteCommand;
        private string delAttachCommand;
        private string delNoteCommand;
        private string modifyNoteCommand;
        #endregion

        #region Constructors

        public ActionAttachNotes(Guid id)
            : this()
        {
            Guid = id;
        }

        public ActionAttachNotes()
            : base()
        {           
        }

        #endregion Constructors

        #region Properties
        public string AddAttachCommand
        {
            get { return addAttachCommand; }
            set { addAttachCommand = value; }
        }

        public string AddNoteCommand
        {
            get { return addNoteCommand; }
            set { addNoteCommand = value; }
        }

        public string DelAttachCommand
        {
            get { return delAttachCommand; }
            set { delAttachCommand = value; }
        }

        public string DelNoteCommand
        {
            get { return delNoteCommand; }
            set { delNoteCommand = value; }
        }

        public string ModifyNoteCommand
        {
            get { return modifyNoteCommand; }
            set { modifyNoteCommand = value; }
        }
        #endregion
    }
}
