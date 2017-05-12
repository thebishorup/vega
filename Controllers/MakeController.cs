using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Data;
using Vega.Model;
using Vega.ViewModel;

namespace vega.Controllers
{
    public class MakeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MakeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("/api/makes")]
        public IEnumerable<MakeViewModel> GetMakes()
        {
            List<Make> makes = new List<Make>(_unitOfWork.Makes.GetAllMakesWithModels());
            return _mapper.Map<List<Make>, List<MakeViewModel>>(makes);
        }

        [HttpGet("/api/models/{id}")]
        public IEnumerable<KeyValuePairViewModel> GetModelsByMakeId(int id)
        {
            List<Modle> models = new List<Modle>(_unitOfWork.Models.Find(m => m.MakeId == id));
            return _mapper.Map<List<Modle>, List<KeyValuePairViewModel>>(models);
        }
    }
}