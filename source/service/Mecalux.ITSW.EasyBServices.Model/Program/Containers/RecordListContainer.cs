using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class RecordListContainer: BaseEntity
    {
        #region Fields

        private List<RecordList> recordLists;

        #endregion Fields

        #region Constructors

        public RecordListContainer()
            : base()
        {
            recordLists = new List<RecordList>();
        }

        #endregion Constructors

        #region Properties

        public IEnumerable<RecordList> RecordListsInternal
        {
            get
            {
                var ordered = recordLists.OrderBy(p => p.Name);
                return ordered;
            }
            set
            {
                recordLists.Clear();
                recordLists.AddRange(value);
            }
        }

        #endregion Properties

        #region Methods

        public void Add(RecordList element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "RecordList can not be null");

                this.recordLists.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "RecordList exception in add operation: " + ex.Message);
            }


        }

        public void Remove(RecordList element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "RecordList can not be null");

                RecordList obj = this.recordLists.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.recordLists.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "RecordList exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(RecordList element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "RecordList can not be null");

                RecordList obj = this.recordLists.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "RecordList doesn't find");
                }
                else
                {
                    this.recordLists.Remove(obj);
                    this.recordLists.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "RecordList exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
