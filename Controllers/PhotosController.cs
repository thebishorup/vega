using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using vega.Data;
using vega.Model;
using vega.ViewModel;

namespace vega.Controllers
{
    [Route("/api/vehicles/{vehicleId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly PhotoSettings photoSettings;
        public PhotosController(IHostingEnvironment host, IUnitOfWork unitOfWork, IMapper mapper, IOptionsSnapshot<PhotoSettings> options)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.host = host;
            this.photoSettings = options.Value;
        }

        [HttpGet]
        public async Task<IEnumerable<PhotoViewModel>> GetPhotos(int vehicleId)
        {
            var photos = await unitOfWork.Photos.GetPhotos(vehicleId);
            return mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoViewModel>>(photos);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int vehicleId, IFormFile file)
        {
            var vehicle = await unitOfWork.Vehicles.GetVehicleAsync(vehicleId);
            if (vehicle == null)
                return NotFound();

            if(file == null) return BadRequest("Please upload file to proceed.");
            if(file.Length == 0) return BadRequest("Empty File.");
            if(file.Length > photoSettings.MaxBytes) return BadRequest("Maximum upload size exceeded.");
            if(!photoSettings.IsSupported(file.FileName)) return BadRequest("Invalid file type");

            var uploadFolderPath = Path.Combine(host.WebRootPath, "uploads");

            //If the folder does not exists, create one!
            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //TODO: Generate tumbnail (using System.Drawing) ans store at location
            var photo = new Photo { FileName = fileName };
            vehicle.Photos.Add(photo);
            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Photo, PhotoViewModel>(photo));
        }
    }
}