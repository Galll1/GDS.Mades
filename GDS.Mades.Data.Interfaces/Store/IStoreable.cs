namespace GDS.Mades.Data.Interfaces.Store
{
    public interface IStoreable
    {
        object StoringId { get; }
        
        string IndexType { get; }
    }
}
