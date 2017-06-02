using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Data;
using vega.Model;
using vega.ViewModel;
using Vega.Data;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public VehiclesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleViewModel>> GetVehicles(VehicleQueryViewModel filterViewModel)
        {
            var filter = _mapper.Map<VehicleQueryViewModel, VehicleQuery>(filterViewModel);
            var vehicles = await _unitOfWork.Vehicles.GetVehiclesAsync(filter);
            return _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleViewModel>>(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.GetVehicleAsync(id);
            if(vehicle == null)
                return NotFound();

            var result = _mapper.Map<Vehicle, VehicleViewModel>(vehicle);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = _mapper.Map<SaveVehicleViewModel, Vehicle>(vehicleViewModel);
            vehicle.CreatedDate = DateTime.Now;
            vehicle.UpdatedDate = vehicle.CreatedDate;
            _unitOfWork.Vehicles.Add(vehicle);
            await _unitOfWork.CompleteAsync();

            vehicle = await _unitOfWork.Vehicles.GetVehicleAsync(vehicle.Id);

            var result = _mapper.Map<Vehicle, VehicleViewModel>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> VehicleUpdate(int id, [FromBody] SaveVehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Get the record from the database
            var vehicle = await _unitOfWork.Vehicles.GetVehicleAsync(id);

            if(vehicle == null)
                return NotFound();

            _mapper.Map<SaveVehicleViewModel, Vehicle>(vehicleViewModel, vehicle);

            //save
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Vehicle, SaveVehicleViewModel>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.GetAsync(id);

            if(vehicle == null)
                return NotFound();

            _unitOfWork.Vehicles.Remove(vehicle);
            await _unitOfWork.CompleteAsync();
            return Ok(id);
        }
    }
}