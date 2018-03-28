using System;

namespace GDS.Mades.Data.Engine.Data
{
    public class CreateStoreInfo
    {
        public CreateStoreInfo(Guid guid, Type indexType)
        {
            Guid = guid;
            IndexType = indexType;
        }

        public Guid Guid { get; private set; }

        public Type IndexType { get; private set; }
    }
}
