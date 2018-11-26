using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class EventContainer: BaseEntity
    {
        #region Fields
        private List<Event> events;
        #endregion

        #region Constructors

        /// <summary>
        /// Default class constructor
        /// </summary>
        public EventContainer()
            : base()
        {
            events = new List<Event>();
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<Event> EventsInternal
        {
            get
            {
                events.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return events;
            }
            set { events = new List<Event>(value); }
        }
        #endregion

        #region Methods

        public void Add(Event element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Event can not be null");

                this.events.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Event exception in add operation: " + ex.Message);
            }


        }

        public void Remove(Event element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Event can not be null");

                Event obj = this.events.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.events.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Event exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(Event element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Event can not be null");

                Event obj = this.events.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "Event doesn't find");
                }
                else
                {
                    this.events.Remove(obj);
                    this.events.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "SecGroup exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
