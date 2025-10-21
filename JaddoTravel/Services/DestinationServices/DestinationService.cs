using AutoMapper;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.IDestinationService
{
    public class DestinationService : IDestinationService
    {
        private readonly IMongoCollection<Destination> _destinationCollection;
        private readonly IMapper _mapper;

        public DestinationService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _destinationCollection = database.GetCollection<Destination>(_databaseSettings.DestinationCollectionName);
            _mapper = mapper;
        }

        public async Task CreateDestinationAsync(CreateDestinationDto createDestinationDto)
        {
           var value = _mapper.Map<Destination>(createDestinationDto);
            await _destinationCollection.InsertOneAsync(value); //MongoDB'ye ekleme işlemi
        }

        public async Task DeleteDestinationAsync(string id)
        {
          await  _destinationCollection.DeleteOneAsync(x => x.DestinationId == id);//MongoDB'den silme işlemi
           
        }

        public async Task<List<ResultDestinationDto>> GetAllDestinationAsync()
        {
            var value = await _destinationCollection.Find(x => true).ToListAsync(); //önce listeleme
            return _mapper.Map<List<ResultDestinationDto>>(value); //sonra mapleme
        }

        public async Task <GetDestinationByIdDto>GetDestinationByIdAsync(string id)
        {
            var value = await _destinationCollection
                .Find(x => x.DestinationId == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetDestinationByIdDto>(value);
        }

        public async Task UpdateDestinationAsync(UpdateDestinationDto updateDestinationDto)
        {
           var value = _mapper.Map<Destination>(updateDestinationDto);
           await _destinationCollection.FindOneAndReplaceAsync(x => x.DestinationId == updateDestinationDto.DestinationId, value);
        }


    }
}
