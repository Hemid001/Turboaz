
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboProject.BusinessLayer.Model.DTO.Request.Account;
using TurboProject.BusinessLayer.Model.DTO.Request.Brand;
using TurboProject.BusinessLayer.Model.DTO.Request.Car;
using TurboProject.BusinessLayer.Model.DTO.Request.CarsModel;
using TurboProject.BusinessLayer.Model.DTO.Request.City;
using TurboProject.BusinessLayer.Model.DTO.Request.EngineSize;
using TurboProject.BusinessLayer.Model.DTO.Request.FuelType;
using TurboProject.BusinessLayer.Model.DTO.Request.Transmission;
using TurboProject.BusinessLayer.Model.DTO.Response.Brand;
using TurboProject.BusinessLayer.Model.DTO.Response.Car;
using TurboProject.BusinessLayer.Model.DTO.Response.CarsModel;
using TurboProject.BusinessLayer.Model.DTO.Response.City;
using TurboProject.BusinessLayer.Model.DTO.Response.EngineSize;
using TurboProject.BusinessLayer.Model.DTO.Response.FuelType;
using TurboProject.BusinessLayer.Model.DTO.Response.Transmission;
using TurboProject.DataLayer.Entity;
using TurboProject.DataLayer.Models.Car;

namespace TurboProject.BusinessLayer.Mapper
{
    public class MapperRoute : Profile
    {
        public MapperRoute()
        {
            CreateMap<RegisterRequestDto, User>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))  
               .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name));

            CreateMap<CreateCarRequestDto, Car>().ReverseMap();

            CreateMap<GetCarResponseDto, Car>().ReverseMap();

            CreateMap<UpdateCarRequestDto, Car>().ReverseMap()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CreateModelRequestDto, CarsModel>().ReverseMap();
            CreateMap<GetModelResponseDto, CarsModel>().ReverseMap();
            CreateMap<UpdateModelRequestDto, CarsModel>().ReverseMap();
            CreateMap<UpdateBrandDto, Brand>().ReverseMap();
            CreateMap<GetBrandDto, Brand>().ReverseMap();
            CreateMap<CreateBrandDto, Brand>().ReverseMap();
            CreateMap<UpdateEngineSizeDto, EngineSize>().ReverseMap();
            CreateMap<CreateEngineSizeDto, EngineSize>().ReverseMap();
            CreateMap<GetEngineSizeDto, EngineSize>().ReverseMap();
            CreateMap<CreateFuelTypeDto, FuelType>().ReverseMap();
            CreateMap<GetFuelTypeDto, FuelType>().ReverseMap();
            CreateMap<CreateTransmissionTypeDto, Transmission>().ReverseMap();
            CreateMap<GetTransmissionTypeDto, Transmission>().ReverseMap();
            CreateMap<GetCityDto, City>().ReverseMap();
            CreateMap<CreateCityDto, City>().ReverseMap();
            CreateMap<GetCarFilteredRequestModel, GetCarFilteredRequestDto>().ReverseMap();





        }
    }
}
