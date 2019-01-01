using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    public class WorkflowUICommandFormat: NameEntity, IAvoidSerializedGuid
    {
        #region Fields
        private int height;
        private bool isDefault;
        private string uiXml;
        private int width;
        private WorkflowUICommandFormatType workflowUICommandFormatType;
        private CheckEntity parententity;
        #endregion

        #region Constructors

        public WorkflowUICommandFormat(Guid id)
            : this()
        {
            Guid = id;
        }

        public WorkflowUICommandFormat(string name)
            : this()
        {
            workflowUICommandFormatType = WorkflowUICommandFormatType.UI;
            Name = name;
            width = 240;
            height = 320;
            uiXml = @"<UIFormat>
    <header>{param:Header}</header>
    <body>

    </body>
    <footer>{param:Footer}</footer>
</UIFormat>";
        }

        public WorkflowUICommandFormat()
            : base()
        {
            UIXml = string.Empty;
        }

        #endregion Constructors

        #region Properties
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public bool IsDefault
        {
            get { return isDefault; }
            set { isDefault = value;}
        }

        public string UIXml
        {
            get { return uiXml; }
            set { uiXml = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public WorkflowUICommandFormatType WorkflowUICommandFormatType
        {
            get { return workflowUICommandFormatType; }
            set { workflowUICommandFormatType = value; }
        }

        public CheckEntity ParentSerializableEntity
        {
            get => parententity;
            set => parententity = value;
        }

        public Guid ParentSerializableEntityVersionId => parententity != null ? parententity.VersionId : Guid.Empty;

        public string ReferencedName
        {
            get
            {
                string result = string.Empty;
                result += this.ParentSerializableEntity.Name + HelperJsonConverter.Separator + this.Name;
                return result;
            }
        }

        public string SerializationParticle =>  HelperJsonConverter.DialogFormatParticle; 
    #endregion
}
}
