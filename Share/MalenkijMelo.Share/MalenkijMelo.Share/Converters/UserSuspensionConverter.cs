using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;

namespace MalenkijMelo.Share.Converters
{
    public static class UserSuspensionConverter
    {
        public static UserSuspensionDto ConvertToUserSuspensionDto(this UserSuspension userSuspension)
        {
            return new UserSuspensionDto()
            {
                Id = userSuspension.Id,
                SuspensionEndDate = userSuspension.SuspensionEndDate,
                SuspendedByAdminId = userSuspension.SuspendedByAdminId,
                UserId = userSuspension.UserId,
            };
        }
        public static UserSuspension ConvertToUserSuspension(this UserSuspensionDto userSuspensionDto)
        {
            return new UserSuspension()
            {
                Id = userSuspensionDto.Id,
                SuspensionEndDate = userSuspensionDto.SuspensionEndDate,
                SuspendedByAdminId = userSuspensionDto.SuspendedByAdminId,
                UserId = userSuspensionDto.UserId,
            };
        }
        public static List<UserSuspensionDto> ConvertListToUserSuspensionDtos(this List<UserSuspension> userSuspensions)
        {
            return userSuspensions.Select(ConvertToUserSuspensionDto).ToList();
        }
        public static List<UserSuspension> ConvertListToUserSuspensions(this List<UserSuspensionDto> userSuspensionDtos)
        {
            return userSuspensionDtos.Select(ConvertToUserSuspension).ToList();
        }
    }
}
