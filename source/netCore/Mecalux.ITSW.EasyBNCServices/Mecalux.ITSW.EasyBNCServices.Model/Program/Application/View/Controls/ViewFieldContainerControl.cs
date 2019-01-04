using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public abstract class ViewFieldContainerControl: ViewControl
    {
        #region Fields

        private List<ViewField> fields;

        #endregion Fields

        #region Constructors

        protected ViewFieldContainerControl(string nameValue, string titleValue)
            : base(nameValue, titleValue)
        {
            this.fields = new List<ViewField>();
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<ViewField> FieldsInternal
        {
            get
            {
                fields.Sort((e1, e2) =>
                {
                    int result = e1.Sequence.CompareTo(e2.Sequence);
                    if (result == 0 && !string.IsNullOrEmpty(e1.Name))
                        result = e1.Name.CompareTo(e2.Name);
                    return result;
                });
                return fields;
            }
            set { fields = new List<ViewField>(value); }
        }
        #endregion

        #region Methods
        protected void AddViewfield(ViewField element)
        {
            if (element == null)
                throw new ArgumentNullException("element", "Element can not be null");

            this.fields.Add(element);
        }
        #endregion
    }
}
