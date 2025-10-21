using AutoMapper;
using JadooTravel.Dtos.RezervationDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.RezervationServices
{
    public class RezervationService : IRezervationService
    {

        private readonly IMongoCollection<Rezervation> _rezervationCollection;
        private readonly IMapper _mapper;


        public RezervationService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _rezervationCollection = database.GetCollection<Rezervation>(_databaseSettings.RezervationCollectionName);
            _mapper = mapper;
        }

        public async Task CreateRezervationAsync(CreateRezervationDto createRezervationDto)
        {
           var value=_mapper.Map<Rezervation>(createRezervationDto);
            await _rezervationCollection.InsertOneAsync(value);
        }

        public async Task DeleteRezervationAsync(string id)
        {
            await _rezervationCollection.DeleteOneAsync(x=>x.RezervationId == id);
        }

        public async Task<List<ResultRezervationDto>> GetAllRezervationASync()
        {
           var value=await _rezervationCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultRezervationDto>>(value);
        }

        public async Task<GetRezervationByIdDto> GetRezervationByIdAsync(string id)
        {
            var value=await _rezervationCollection
                .Find(x=>x.RezervationId==id)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetRezervationByIdDto>(value);
        }

        public async Task UpdateRezervationAsync(UpdateRezervationDto updateRezervationDto)
        {
            var value = _mapper.Map<Rezervation>(updateRezervationDto);
            await _rezervationCollection.FindOneAndReplaceAsync(x=>x.RezervationId==updateRezervationDto.RezervationId,value);
        }
    }
}
