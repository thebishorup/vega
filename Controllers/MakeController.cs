using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Data;
using Vega.Model;
using Vega.ViewModel;

namespace vega.Controllers
{
    public class MakeController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public MakeController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeViewModel>> GetMakes()
        {
            var makes = await context.VehicleMakes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeViewModel>>(makes);
        }
    }
}