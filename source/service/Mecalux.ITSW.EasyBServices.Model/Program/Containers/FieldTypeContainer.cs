using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class FieldTypeContainer: BaseEntity
    {
        #region Fields
        private List<FieldType> fieldTypes;
        #endregion

        #region Constructors

        /// <summary>
        /// Default class constructor
        /// </summary>
        public FieldTypeContainer()
            : base()
        {
            fieldTypes = new List<FieldType>();
            Guid = new Guid(GuidPrefix.FieldTypeContainer + Guid.ToString().Substring(8));

        }

        #endregion Constructors

        #region Properties
      
        public IEnumerable<FieldType> FieldTypeListsInternal
        {
            get
            {
                var ordered = fieldTypes.OrderBy(p => p.Name);
                return ordered;
            }
            set
            {
                fieldTypes.Clear();
                fieldTypes.AddRange(value);
            }
        }

        #endregion Properties

        #region Methods

        public void Add(FieldType element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "FieldType can not be null");

                this.fieldTypes.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "FieldType exception in add operation: " + ex.Message);
            }


        }

        public bool Remove(FieldType element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "FieldType can not be null");

                FieldType obj = this.fieldTypes.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.fieldTypes.Remove(obj);
                    // TODO BASE DE DATOS
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "FieldType exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(FieldType element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "FieldType can not be null");

                FieldType obj = this.fieldTypes.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "FieldType doesn't find");
                }
                else
                {
                    this.fieldTypes.Remove(obj);
                    this.fieldTypes.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "FieldType exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
