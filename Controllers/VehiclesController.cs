using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Data;
using vega.Model;
using vega.ViewModel;

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

        public IEnumerable<VehicleViewModel> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>(_unitOfWork.Vehicles.GetAll());
            return _mapper.Map<List<Vehicle>, List<VehicleViewModel>>(vehicles);
        }

        [HttpPost()]
        public IActionResult CreateVehicle([FromBody] VehicleViewModel vehicleViewModel)
        {
            var vehicle = _mapper.Map<VehicleViewModel, Vehicle>(vehicleViewModel);
            vehicle.CreatedDate = DateTime.Now;
            vehicle.UpdatedDate = vehicle.CreatedDate;
            _unitOfWork.Vehicles.Add(vehicle);
            _unitOfWork.Complete();

            var result = _mapper.Map<Vehicle, VehicleViewModel>(vehicle);

            return Ok(result);
        }

        [HttpPut("/api/vehicle/update")]
        public IActionResult Update([FromBody] VehicleViewModel vehicleViewModel)
        {
            return Ok();
        }

        [HttpDelete("/api/vehicle/delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}