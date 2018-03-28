using GDS.Mades.Data.Core;
using GDS.Mades.Data.Interfaces.Core;
using Unity;

namespace GDS.Mades.Data.Engine
{
    public static class MadesModule
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterInstance<IMarket>(new MadesMarket());
        }
    }
}
