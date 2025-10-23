using JadooTravel.Dtos.RezervationDtos;

namespace JadooTravel.Services.RezervationServices
{
    public interface IRezervationService
    {
        Task<List<ResultRezervationDto>> GetAllRezervationAsync();

        Task CreateRezervationAsync(CreateRezervationDto createRezervationDto);

        Task UpdateRezervationAsync(UpdateRezervationDto updateRezervationDto);

        Task DeleteRezervationAsync(string id);

        Task <GetRezervationByIdDto>GetRezervationByIdAsync(string id);

    }
}
