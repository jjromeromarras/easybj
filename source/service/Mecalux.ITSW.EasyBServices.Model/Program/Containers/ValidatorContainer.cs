using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class ValidatorContainer: BaseEntity
    {
        #region Fields
        private List<Validator> validators;
        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default class constructor
        /// </summary>
        public ValidatorContainer()
            : base()
        {
            validators = new List<Validator>();
            Guid = new Guid(GuidPrefix.ValidatorContainer + Guid.ToString().Substring(8));
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<Validator> EntitiesInternal
        {
            get
            {
                validators.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return validators;
            }
            set { validators = new List<Validator>(value); }
        }
        #endregion

        #region Methods

        public void Add(Validator element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Validator can not be null");

                this.validators.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Validator exception in add operation: " + ex.Message);
            }


        }

        public void Remove(Validator element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Validator can not be null");

                Validator obj = this.validators.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.validators.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Validator exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(Validator element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "Validator can not be null");

                Validator obj = this.validators.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "Validator doesn't find");
                }
                else
                {
                    this.validators.Remove(obj);
                    this.validators.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "Validator exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
