using TurboProject.DataLayer.Context;
using TurboProject.DataLayer.Repository.Impl;
using TurboProject.DataLayer.Repository.Interface;
using TurboProject.DomainLayer.UoW.Interface;

namespace TurboProject.DomainLayer.UoW.Impl
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDbContext context;
        public IModelRepository modelRepository { get; private set; }
        public IBrandRepository brandRepository { get; private set; }
        public ICarRepository carRepository {  get; private set; }
        public IEngineSizeRepository engineSizeRepository { get; private set; }
        public IFuelTypeRepository fuelTypeRepository { get; private set; }
        public ITransmissionRepository transmissionRepository { get; private set; }
        public ICityRepository cityRepository { get; private set; }
        public IImageRepository imageRepository { get; private set; }






        public UnitofWork(AppDbContext context,ICarRepository carRepository, IModelRepository modelRepository,
          IBrandRepository brandRepository, IEngineSizeRepository engineSizeRepository,
          IFuelTypeRepository fuelTypeRepository, ITransmissionRepository transmissionRepository,
          ICityRepository cityRepository, IImageRepository imageRepository
          )
        {
            this.context = context;
            this.carRepository = carRepository;
            this.modelRepository = modelRepository;
            this.brandRepository = brandRepository;
            this.engineSizeRepository = engineSizeRepository;
            this.fuelTypeRepository = fuelTypeRepository;
            this.transmissionRepository = transmissionRepository;
            this.cityRepository = cityRepository;
        }

        public async Task<int> Commit()
        {
            return await context.SaveChangesAsync();
        }
    }

}
