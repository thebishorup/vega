using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Data;

namespace vega.Controllers
{
    public class VehicleController : Controller
    {
        public VehicleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            
        }
    }
}