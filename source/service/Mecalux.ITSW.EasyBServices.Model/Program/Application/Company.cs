using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class Company: NameEntity
    {
        #region Fields (4)

        private string address;
        private string city;
        private string country;
        private int postalCode;

        #endregion Fields

        #region Constructor
        public Company()
            : base()
        {
            Address =
            City =
            Country = string.Empty;
        }
        #endregion

        #region Properties (5)

        /// <summary>
        /// Company's address
        /// </summary>
        public string Address
        {
            get => address; 
            set => address = value;
        }

        /// <summary>
        /// Company's city
        /// </summary>
        public string City
        {
            get => city; 
            set => city = value;
        }

        /// <summary>
        /// Company's country
        /// </summary>
        public string Country
        {
            get => country; 
            set => country = value;
        }

        /// <summary>
        /// Company's name
        /// </summary>
        public override string Name
        {
            get => string.Empty;            
            set => base.Name = value;
        }

        /// <summary>
        /// Company's ZipCode
        /// </summary>
        public int ZipCode
        {
            get => postalCode; 
            set => postalCode = value;
        }
        #endregion Properties
    }
}
