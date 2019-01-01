using System;
using System.Collections.Generic;
using System.Text;

namespace Mecalux.ITSW.EasyB.Model
{
    public class ViewGraphControlSerie : CheckEntity, IAvoidSerializedGuid
    {
        #region Fields

        private string column;
        private string label;
        private CheckEntity parentEntity;
        
        #endregion Fields

        #region Constructors

        public ViewGraphControlSerie(Guid id)
            : this()
        {
            Guid = id;
        }

        public ViewGraphControlSerie()
            : base()
        {
            Column = string.Empty;
        }

        #endregion Constructors

        #region Properties       
        public string Column
        {
            get { return column; }
            set { column = value; }
        }

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        public CheckEntity ParentSerializableEntity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Guid ParentSerializableEntityVersionId => throw new NotImplementedException();

        public string ReferencedName
        {
            get { return (this.parentEntity as ViewGraphControl).ReferencedName + HelperJsonConverter.Separator + this.Column; }
        }

        public string SerializationParticle
        {
            get { return HelperJsonConverter.ViewGraphControlSerieParticle; }
        }
        #endregion
    }
}
