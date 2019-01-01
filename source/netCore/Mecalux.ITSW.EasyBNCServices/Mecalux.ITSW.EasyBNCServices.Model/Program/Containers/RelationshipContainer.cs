using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class RelationshipContainer: BaseEntity
    {
        #region Fields
        private List<Relationship> relationships;
        #endregion

        #region Constructors

        public RelationshipContainer()
            : base()
        {
            this.relationships = new List<Relationship>();
            Guid = new Guid(GuidPrefix.RelationshipContainer + Guid.ToString().Substring(8));

        }

        #endregion Constructors

        #region Properties

        private IEnumerable<Relationship> RelationshipsInternal
        {
            get
            {
                relationships.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return relationships;
            }
            set { relationships = new List<Relationship>(value); }
        }

        #endregion Properties

        #region Methods

        public void Add(Relationship element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Relationship can not be null");

                this.relationships.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Relationship exception in add operation: " + ex.Message);
            }


        }

        public void Remove(Relationship element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Relationship can not be null");

                Relationship obj = this.relationships.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.relationships.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Relationship exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(Relationship element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Relationship can not be null");

                Relationship obj = this.relationships.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "Relationship doesn't find");
                }
                else
                {
                    this.relationships.Remove(obj);
                    this.relationships.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Relationship exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
