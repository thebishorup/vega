using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Data;
using Vega.Model;
using Vega.ViewModel;

namespace vega.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FeatureController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        [HttpGet("/api/features")]
        public IEnumerable<FeatureViewModel> GetFeatures()
        {
            List<Feature> features = new List<Feature>(_unitOfWork.Features.GetAll());
            return _mapper.Map<List<Feature>, List<FeatureViewModel>>(features);
        }
    }
}