using GDS.Mades.Data.Core.Storeable;
using GDS.Mades.Data.Interfaces.Store;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace GDS.Mades.DataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMadesDataService" in both code and config file together.
    [ServiceContract]
    [ServiceKnownType(typeof(JsonStoreable))]
    public interface IMadesDataService
    {
        [OperationContract]
        void CreateStore(string indexType, Guid storeId);

        [OperationContract]
        IList<JsonStoreable> GetData(Guid storeId);

        [OperationContract]
        void StoreData(Guid storeId, IStoreable dataToStore);

        [OperationContract]
        void StoreMultipleData(Guid storeId, IEnumerable<IStoreable> dataToStore);
    }
}
