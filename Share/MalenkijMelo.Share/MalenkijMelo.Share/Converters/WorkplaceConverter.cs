using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Converters
{
    public static class WorkplaceConverter
    {
        public static WorkplaceDto ConvertToWorkplaceDto(this Workplace workplace)
        {
            return new WorkplaceDto()
            {
                PlaceId = workplace.Id,
                PlaceName = workplace.PlaceName,
            };
        }

        public static Workplace ConvertToUserJobAction(this WorkplaceDto workplaceDto)
        {
            return new Workplace()
            {
                Id = workplaceDto.PlaceId,
                PlaceName = workplaceDto.PlaceName,
            };
        }

        public static List<WorkplaceDto> ConvertListToWorkplaceDtos(this List<Workplace> workplaces)
        {
            return workplaces.Select(ConvertToWorkplaceDto).ToList();
        }

        public static List<Workplace> ConvertListToWorkplaces(this List<WorkplaceDto> workplaceDtos)
        {
            return workplaceDtos.Select(ConvertToUserJobAction).ToList();
        }
    }
}
