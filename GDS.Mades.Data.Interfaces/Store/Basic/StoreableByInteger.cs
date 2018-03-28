using System;

namespace GDS.Mades.Data.Interfaces.Store.Basic
{
    public abstract class StoreableByInteger : IStoreable
    {
        public abstract object StoringId { get; }

        public string IndexType => typeof(int).ToString();
    }
}
