using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class ViewGroupContainer: BaseEntity
    {
        #region Fields
        /// <summary>
        /// The list of ViewGroup
        /// </summary>
        private List<ViewGroup> viewGroups;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default class constructor
        /// </summary>
        public ViewGroupContainer()
            : base()
        {
            viewGroups = new List<ViewGroup>();
        }

        #endregion Constructors

        #region Properties
        private IEnumerable<ViewGroup> ViewGroupsInternal
        {
            get
            {
                viewGroups.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return viewGroups;
            }
            set { viewGroups = new List<ViewGroup>(value); }
        }
        #endregion

        #region Methods
        public void Add(ViewGroup element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "ViewGroup can not be null");

                this.viewGroups.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "ViewGroup exception in add operation: " + ex.Message);
            }


        }

        public void Remove(ViewGroup element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "ViewGroup can not be null");

                ViewGroup obj = this.viewGroups.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.viewGroups.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "ViewGroup exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(ViewGroup element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "ViewGroup can not be null");

                ViewGroup obj = this.viewGroups.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "ViewGroup doesn't find");
                }
                else
                {
                    this.viewGroups.Remove(obj);
                    this.viewGroups.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "ViewGroup exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
