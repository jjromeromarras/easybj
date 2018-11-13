using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class RFMenuItemContainer: BaseEntity
    {
        #region Fields
        private List<RFMenuItem> rfMenuItems;
        #endregion

        #region Constructor
        public RFMenuItemContainer()
            : base()
        {
            rfMenuItems = new List<RFMenuItem>();
        }
        #endregion

        #region Properties
        [JsonProperty]
        public IEnumerable<RFMenuItem> RFMenuItemsInternal
        {
            get
            {
                rfMenuItems.Sort((e1, e2) =>
                {
                    int result = e1.Name.CompareTo(e2.Name);
                    if (result == 0)
                        result = e1.GetIdentifier().CompareTo(e2.GetIdentifier());
                    return result;
                });
                return rfMenuItems;
            }
            set => rfMenuItems = new List<RFMenuItem>(value);
        }
        #endregion

        #region Methods

        public void Add(RFMenuItem element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "RFMenuItem can not be null");

                this.rfMenuItems.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "RFMenuItem exception in add operation: " + ex.Message);
            }


        }

        public void Remove(RFMenuItem element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "RFMenuItem can not be null");

                RFMenuItem menu = this.rfMenuItems.Find(p => p.Guid == element.Guid);
                if (menu != null)
                {
                    this.rfMenuItems.Remove(menu);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "RFMenuItem exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(RFMenuItem element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "RFMenuItem can not be null");

                RFMenuItem menu = this.rfMenuItems.Find(p => p.Guid == element.Guid);
                if (menu == null)
                {
                    throw new ArgumentNullException("element", "RFMenuItem doesn't find");
                }
                else
                {
                    this.rfMenuItems.Remove(menu);
                    this.rfMenuItems.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "RFMenuItem exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
