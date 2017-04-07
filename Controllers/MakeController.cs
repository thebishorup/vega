using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Persistence;
using Vega.Data;
using Vega.Model;
using Vega.ViewModel;

namespace vega.Controllers
{
    public class MakeController : Controller
    {
        private readonly VegaDbContext context;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public MakeController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
            _unitOfWork = new UnitOfWork(this.context);
        }

        [HttpGet("/api/makes")]
        public IEnumerable<MakeViewModel> GetMakes()
        {
            List<Make> makes = new List<Make>(_unitOfWork.Makes.GetAll());
            return mapper.Map<List<Make>, List<MakeViewModel>>(makes);
        }

        [HttpGet("/api/models")]
        public IEnumerable<ModelViewModel> GetModels(int id)
        {
            List<Modle> models = new List<Modle>(_unitOfWork.Models.GetAll());
            return mapper.Map<List<Modle>, List<ModelViewModel>>(models);
        }

        [HttpGet("/api/models/{id}")]
        public IEnumerable<ModelViewModel> GetModelsByMakeId(int id)
        {
            List<Modle> models = new List<Modle>(_unitOfWork.Models.Find(m => m.MakeId == id));
            return mapper.Map<List<Modle>, List<ModelViewModel>>(models);
        }

    }
}