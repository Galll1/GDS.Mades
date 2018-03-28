using GDS.Mades.Data.Engine.Data;
using GDS.Mades.Data.Mock.Store;
using GDS.Mades.DataService.Client.MadesDataService;
using System.Windows;

namespace GDS.Mades.DataService.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MadesDataServiceClient service = new MadesDataServiceClient();
            CreateStoreInfo info = JsonStoreMock.GenerateRandomStore();
            
            service.CreateStore(info.IndexType.ToString(), info.Guid);

            service.StoreData(info.Guid, JsonStoreMock.GetSingleData(info.IndexType));

            service.StoreMultipleData(info.Guid, JsonStoreMock.GetMultiData(info.IndexType).ToArray());

            var data = service.GetData(info.Guid);
        }
    }
}
