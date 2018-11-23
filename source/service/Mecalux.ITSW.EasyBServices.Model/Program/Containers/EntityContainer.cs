using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyB.Model
{
    
    public class EntityContainer: BaseEntity
    {
        #region Fields
        private List<Entity> entities;
        #endregion

        #region Constructors

        /// <summary>
        /// Default class constructor
        /// </summary>
        public EntityContainer()
            : base()
        {
            entities = new List<Entity>();
            Guid = new Guid(GuidPrefix.EntityContainer + Guid.ToString().Substring(8));

        }

        #endregion Constructors

        #region Properties

        public IEnumerable<Entity> EntityListsInternal
        {
            get
            {
                var ordered = entities.OrderBy(p => p.Name);
                return ordered;
            }
            set
            {
                entities.Clear();
                entities.AddRange(value);
            }
        }

        #endregion Properties

        #region Methods

        public void Add(Entity element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Entity can not be null");
                
                this.entities.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Entity exception in add operation: " + ex.Message);
            }


        }

        public bool Remove(Entity element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Entity can not be null");

                Entity obj = this.entities.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.entities.Remove(obj);
                    // TODO BASE DE DATOS
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Entity exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(Entity element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Entity can not be null");

                Entity obj = this.entities.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "Entity doesn't find");
                }
                else
                {
                    this.entities.Remove(obj);
                    this.entities.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Entity exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
