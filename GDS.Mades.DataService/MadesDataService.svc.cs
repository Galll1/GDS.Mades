using System;
using System.Collections.Generic;
using System.Linq;
using GDS.Mades.Data.Core.Storeable;
using GDS.Mades.Data.Engine;
using GDS.Mades.Data.Interfaces.Core;
using GDS.Mades.Data.Interfaces.Store;
using Unity;

namespace GDS.Mades.DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MadesDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MadesDataService.svc or MadesDataService.svc.cs at the Solution Explorer and start debugging.
    public class MadesDataService : IMadesDataService
    {
        private static readonly IUnityContainer container = new UnityContainer();
        static MadesDataService()
        {
            MadesModule.Register(container);
        }

        public void CreateStore(string indexType, Guid storeId)
        {
            Type typeFromString = Type.GetType(indexType);
            IMarket market = container.Resolve<IMarket>();

            market.CreateStore(typeFromString, storeId);
        }

        public IList<JsonStoreable> GetData(Guid storeId)
        {
            IMarket market = container.Resolve<IMarket>();

            return market.RetrieveStore(storeId).GetData().Cast<JsonStoreable>().ToList();
        }

        public void StoreData(Guid storeId, IStoreable dataToStore)
        {
            IMarket market = container.Resolve<IMarket>();
            IStore store = market.RetrieveStore(storeId);

            store.StoreData(dataToStore);
        }

        public void StoreMultipleData(Guid storeId, IEnumerable<IStoreable> dataToStore)
        {
            IMarket market = container.Resolve<IMarket>();
            IStore store = market.RetrieveStore(storeId);

            store.StoreData(dataToStore);
        }
    }
}
