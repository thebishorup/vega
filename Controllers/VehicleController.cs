using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Data;
using vega.Model;
using vega.ViewModel;

namespace vega.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public VehicleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<VehicleViewModel> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>(_unitOfWork.Vehicles.GetAll());
            return _mapper.Map<List<Vehicle>, List<VehicleViewModel>>(vehicles);
        }

        [HttpPost("/api/vehicle/create")]
        public IActionResult Create([FromBody] VehicleViewModel vehicleViewModel)
        {
            return Ok();
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