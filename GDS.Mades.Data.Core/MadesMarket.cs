using GDS.Mades.Data.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GDS.Mades.Data.Core
{
    public class MadesMarket : IMarket
    {
        private IList<IStore> stores;

        public MadesMarket()
        {
            stores = new List<IStore>();
        }

        public void CreateStore(Type indexType, Guid storeId)
        {
            if (CheckStoreExists(storeId))
                throw new NotSupportedException($"Cannot create store: Store with provided Id({storeId}) already created.");

            stores.Add(new MadesStore(indexType, storeId));
        }

        public IStore RetrieveStore(Guid storeId)
        {
            if(CheckStoreExists(storeId) == false)
                throw new NotSupportedException($"Cannot retrieve store: Store with provided Id({storeId}) is not created yet.");

            return stores.First(store => store.StoreId == storeId);
        }

        private bool CheckStoreExists(Guid storeId)
        {
            return stores.Any(store => store.StoreId == storeId);
        }
    }
}
