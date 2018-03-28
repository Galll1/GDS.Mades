using GDS.Mades.Data.Interfaces.Core;
using GDS.Mades.Data.Interfaces.Store;
using System;
using System.Collections.Generic;

namespace GDS.Mades.Data.Core
{
    public class MadesStore : IStore
    {
        private IList<IStoreable> store;
        private readonly Type indexType;

        public Guid StoreId { get; }

        public MadesStore(Type indexType, Guid storeId)
        {
            this.indexType = indexType;
            StoreId = storeId;
            store = new List<IStoreable>();
        }

        public IList<IStoreable> GetData()
        {
            return store;
        }

        public void StoreData(IStoreable data)
        {
            if(data == null)
                throw new NotSupportedException($"Data to store cannot be null.");
            if (data.IndexType == indexType.ToString() == false)
                throw new NotSupportedException($"Data to store type ({data.IndexType}) mismatch with stored ({indexType}).");

            lock (store)
            {
                store.Add(data);
            }
        }

        public void StoreData(IEnumerable<IStoreable> dataToStore)
        {
            foreach(IStoreable storeable in dataToStore)
            {
                StoreData(storeable);
            }
        }
    }
}
