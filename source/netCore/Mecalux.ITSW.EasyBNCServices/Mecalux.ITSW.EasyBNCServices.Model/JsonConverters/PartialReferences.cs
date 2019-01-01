using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class PartialReferences
    {
        #region Fields

        public IEnumerable<ApplicationTagContainer> LocalAndParentsApplicationTagContainers;
        private readonly ConcurrentDictionary<Type, IList<JsonProperty>> orderedProperties = new ConcurrentDictionary<Type, IList<JsonProperty>>();
        private readonly ConcurrentDictionary<int, object> referenceObjects = new ConcurrentDictionary<int, object>();
        private readonly ConcurrentDictionary<Guid, IBaseEntity> references = new ConcurrentDictionary<Guid, IBaseEntity>();
        private readonly ConcurrentDictionary<string, IBaseEntity> referencesAvoidedGuid = new ConcurrentDictionary<string, IBaseEntity>();
        private ConcurrentDictionary<Guid, HashSet<string>> referencesByVersionId = new ConcurrentDictionary<Guid, HashSet<string>>();

        #endregion Fields

        #region Properties

        public ApplicationTagContainer ApplicationTagContainer { set; get; }
        public ConcurrentDictionary<Type, IList<JsonProperty>> OrderedProperties { get { return orderedProperties; } }
        public ConcurrentDictionary<int, object> ReferenceObjects { get { return referenceObjects; } }
        public ConcurrentDictionary<Guid, IBaseEntity> References { get { return references; } }
        public ConcurrentDictionary<string, IBaseEntity> ReferencesAvoidedGuid { get { return referencesAvoidedGuid; } }
        public ConcurrentDictionary<Guid, HashSet<string>> ReferencesByVersionId { get { return referencesByVersionId; } }

        #endregion Properties

        #region Methods

        public void ClearCachedReferences()
        {
            references.Clear();
            referenceObjects.Clear();
            referencesAvoidedGuid.Clear();
            orderedProperties.Clear();
            referencesByVersionId.Clear();
            
        }

        #endregion Methods
    }
}
