using ParkingTerminals.ApplicationServices.GetParkingTerminalListUseCase;
using System.Net;
using Newtonsoft.Json;
using ParkingTerminals.ApplicationServices.Ports;

namespace ParkingTerminals.InfrastructureServices.Presenters
{
    public class ParkingTerminalListPresenter : IOutputPort<GetParkingTerminalListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ParkingTerminalListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetParkingTerminalListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.ParkingTerminals) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
