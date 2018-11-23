using Newtonsoft.Json;
using System;

namespace Mecalux.ITSW.EasyB.Model
{
    [JsonObject]
    public class SearchingCategory: BaseEntity
    {
        #region Fields
        private Category category;
        private string targetViewInternal;
        #endregion

        #region Constructors

        public SearchingCategory(Category categorySrc, string viewList)
            : this()
        {
            category = categorySrc;
            targetViewInternal = viewList;
        }

        public SearchingCategory(Guid id)
            : this()
        {
            Guid = id;
        }

        public SearchingCategory()
            : base()
        {
        }

        #endregion Constructors

        #region Properties

        public Category Category
        {
            get => category;
            set => category = value;
        }

        private string TargetViewInternal
        {
            get => targetViewInternal;
            set => targetViewInternal = value; 
        }

        #endregion Properties
    }
}
