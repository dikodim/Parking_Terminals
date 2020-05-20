using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingTerminals.DomainObjects;
using ParkingTerminals.ApplicationServices.GetParkingTerminalListUseCase;
using ParkingTerminals.InfrastructureServices.Presenters;

namespace ParkingTerminals.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingTerminalController : ControllerBase
    {
        private readonly ILogger<ParkingTerminalController> _logger;
        private readonly IGetParkingTerminalListUseCase _getParkingTerminalListUseCase;

        public ParkingTerminalController(ILogger<ParkingTerminalController> logger,
                                IGetParkingTerminalListUseCase getParkingTerminalListUseCase)
        {
            _logger = logger;
            _getParkingTerminalListUseCase = getParkingTerminalListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllParkingTerminals()
        {
            var presenter = new ParkingTerminalListPresenter();
            await _getParkingTerminalListUseCase.Handle(GetParkingTerminalListUseCaseRequest.CreateAllParkingTerminalsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{parkingTerminalId}")]
        public async Task<ActionResult> GetParkingTerminal(long parkingTerminalId)
        {
            var presenter = new ParkingTerminalListPresenter();
            await _getParkingTerminalListUseCase.Handle(GetParkingTerminalListUseCaseRequest.CreateParkingTerminalRequest(parkingTerminalId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("District/{district}")]
        public async Task<ActionResult> GetDistrictFilter(string district)
        {
            var presenter = new ParkingTerminalListPresenter();
            await _getParkingTerminalListUseCase.Handle(GetParkingTerminalListUseCaseRequest.CreateDistrictParkingTerminalsRequest(district), presenter);
            return presenter.ContentResult;
        }
    }
}
