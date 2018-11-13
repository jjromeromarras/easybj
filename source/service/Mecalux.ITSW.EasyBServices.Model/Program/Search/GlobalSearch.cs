using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    [JsonObject]
    public class GlobalSearch: CheckEntity
    {
        #region Fields
        private int maxResultsPerCategory;
        private List<SearchingCategory> searchingCategories;
        #endregion

        #region Constructors

        public GlobalSearch(Guid id)
            : this()
        {
            Guid = id;
        }

        public GlobalSearch(CheckStatus status = CheckStatus.New)
            : this()
        {
            this.CheckStatus = CheckStatus.New;
        }

        public GlobalSearch()
            : base()
        {
            CheckStatus = CheckStatus.New;
            searchingCategories = new List<SearchingCategory>();
        }

        #endregion Constructors

        #region Properties
        public int MaxResultsPerCategory
        {
            get => maxResultsPerCategory; 
            set => maxResultsPerCategory = value;
        }

        private IEnumerable<SearchingCategory> SearchingCategoriesInternal
        {
            get
            {
                searchingCategories.Sort((e1, e2) => e1.Category.CompareTo(e2.Category));
                return searchingCategories;
            }
            set { searchingCategories = new List<SearchingCategory>(value); }
        }

        #endregion Properties
    }
}
