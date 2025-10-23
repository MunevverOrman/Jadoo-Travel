using AutoMapper;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Dtos.TripPlanDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.TripPlanServices
{
    public class TripPlanService : ITripPlanService
    {
        private readonly IMongoCollection<TripPlan> _tripPlanCollection;
        private readonly IMapper _mapper;

        public TripPlanService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _tripPlanCollection = database.GetCollection<TripPlan>(_databaseSettings.TripPlanCollectionName);
            _mapper = mapper;
        }


        public async Task CreateTripPlanAsync(CreateTripPlanDto createTripPlanDto)
        {
            var value = _mapper.Map<TripPlan>(createTripPlanDto);
            await _tripPlanCollection.InsertOneAsync(value);
        }

        public async Task DeleteTripPlanAsync(string id)
        {
            await _tripPlanCollection.DeleteOneAsync(x => x.TripPlanId == id);

        }

        public async Task<List<ResultTripPlanDto>> GetAllTripPlanAsync()
        {
            var value= await _tripPlanCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultTripPlanDto>>(value);
        }

        public async  Task<GetTripPlanByIdDto> GetTripPlanByIdAsync(string id)
        {
            var value = await _tripPlanCollection.Find(x => x.TripPlanId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTripPlanByIdDto>(value);
        }

        public async Task UpdateTripPlanAsync(UpdateTripPlanDto updateTripPlanDto)
        {
            var value = _mapper.Map<TripPlan>(updateTripPlanDto);
            await _tripPlanCollection.FindOneAndReplaceAsync(x => x.TripPlanId == updateTripPlanDto.TripPlanId, value);
        }
    }
}
