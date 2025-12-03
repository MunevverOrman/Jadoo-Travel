using JadooTravel.Dtos.DestinationDtos;
using System.Collections.Generic;

namespace JadooTravel.Models
{
    public class StatisticsViewModel
    {
        public List<ResultDestinationDto> LastDestinations { get; set; }
        public List<ResultDestinationDto> LastDestinationsForCards { get; set; }
    }
}
