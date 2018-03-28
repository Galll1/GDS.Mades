using System;

namespace GDS.Mades.Data.Interfaces.Core
{
    public interface IMarket
    {
        void CreateStore(Type indexType, Guid uniqueId);

        IStore RetrieveStore(Guid uniqueId);
    }
}
