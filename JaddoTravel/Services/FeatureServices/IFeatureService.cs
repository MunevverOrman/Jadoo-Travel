using JadooTravel.Dtos.FeatureDtos;

namespace JadooTravel.Services.FeatureService
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();

        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);

        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);

        Task DeleteFeatureAsync(string id);

        Task<GetFeatureByIdDto> GetFeatureByIdAsync(string id);
    }
}
