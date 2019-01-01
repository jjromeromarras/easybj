using Mecalux.ITSW.EasyBService.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class ResourceContainer: BaseEntity
    {
        #region Fields
        private List<Resource> resources;
        #endregion

        #region Constructors

        public ResourceContainer()
            : base()
        {
            resources = new List<Resource>();
        }
        #endregion Constructors

        #region Properties
        private IEnumerable<Resource> ResourcesInternal
        {
            get => resources.OrderBy(p => p.Name).ToList();
            set
            {
                resources.Clear();
                resources.AddRange(value);
            }
        }
        #endregion

        #region Methods

        public void Add(Resource element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Resource can not be null");

                this.resources.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Resource exception in add operation: " + ex.Message);
            }


        }

        public void Remove(Resource element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Resource can not be null");

                Resource obj = this.resources.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.resources.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Resource exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(Resource element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Resource can not be null");

                Resource obj = this.resources.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "Resource doesn't find");
                }
                else
                {
                    this.resources.Remove(obj);
                    this.resources.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Resource exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
