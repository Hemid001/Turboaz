using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboProject.BusinessLayer.Model.DTO.Response.Image;
using TurboProject.BusinessLayer.Service.Interface;
using TurboProject.DomainLayer.UoW.Impl;
using TurboProject.DomainLayer.UoW.Interface;

namespace TurboProject.BusinessLayer.Service.Impl
{
    public class ImageService : IImageService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IWebHostEnvironment env;
        private readonly IMapper mapper;
        private readonly string _imageRootPath = "wwwroot/images/cars";

        public ImageService(IUnitofWork unitofWork, IWebHostEnvironment env, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.env = env;
            this.mapper = mapper;
        }
        public async Task DeleteImage(int imageId)
        {
           var image = await unitofWork.imageRepository.GetById(imageId);
            if (image == null)
                throw new KeyNotFoundException("Image not found");
            var filePath = Path.Combine(env.WebRootPath, image.ImageURL.TrimStart('/'));
            if (File.Exists(filePath))
                File.Delete(filePath);
            unitofWork.imageRepository.Delete(image);
            await unitofWork.Commit();


        }

        public Task<List<GetImageDto>> GetImagesByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public Task<GetImageDto?> GetPrimaryImageByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public Task UploadImage(int carId, IFormFile file, bool isPrimary)
        {
            throw new NotImplementedException();
        }
    }
}
