using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class RecordContainer: BaseEntity
    {
        #region Fields

        private List<Record> records;

        #endregion Fields

        #region Constructors

        public RecordContainer()
            : base()
        {
            records = new List<Record>();
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<Record> RecordsInternal
        {
            get
            {
                records.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return records;
            }
            set { records = new List<Record>(value); }
        }
        #endregion

        #region Methods

        public void Add(Record element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Record can not be null");

                this.records.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Record exception in add operation: " + ex.Message);
            }


        }

        public void Remove(Record element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Record can not be null");

                Record obj = this.records.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.records.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Record exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(Record element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Record can not be null");

                Record obj = this.records.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "Record doesn't find");
                }
                else
                {
                    this.records.Remove(obj);
                    this.records.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Record exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
