using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class MenuItemContainer: BaseEntity
    {
        #region Fields
        private List<MenuItem> menuItems;
        #endregion

        #region Constructor
        public MenuItemContainer()
            : base()
        {
            menuItems = new List<MenuItem>();
        }
        #endregion

        #region Properties
        [JsonProperty]
        public IEnumerable<MenuItem> MenuItemsInternal
        {
            get
            {
                menuItems.Sort((e1, e2) =>
                {
                    int result = e1.Name.CompareTo(e2.Name);
                    if (result == 0)
                        result = e1.GetIdentifier().CompareTo(e2.GetIdentifier());
                    return result;
                });
                return menuItems;
            }
            set => menuItems = new List<MenuItem>(value);
        }
        #endregion

        #region Methods

        public void Add(MenuItem element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "MenuItem can not be null");

                this.menuItems.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "MenuItem exception in add operation: " + ex.Message);
            }


        }

        public void Remove(MenuItem element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "MenuItem can not be null");

                MenuItem menu = this.menuItems.Find(p => p.Guid == element.Guid);
                if (menu != null)
                {
                    this.menuItems.Remove(menu);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "MenuItem exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(MenuItem element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "MenuItem can not be null");

                MenuItem menu = this.menuItems.Find(p => p.Guid == element.Guid);
                if (menu == null)
                {
                    throw new ArgumentNullException("element", "MenuItem doesn't find");
                }
                else
                {
                    this.menuItems.Remove(menu);
                    this.menuItems.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "MenuItem exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
