using GDS.Mades.Data.Interfaces.Store;
using System;
using System.Collections.Generic;

namespace GDS.Mades.Data.Interfaces.Core
{
    public interface IStore
    {
        Guid StoreId { get; }
        IList<IStoreable> GetData();
        void StoreData(IStoreable data);
        void StoreData(IEnumerable<IStoreable> dataToStore);
    }
}
