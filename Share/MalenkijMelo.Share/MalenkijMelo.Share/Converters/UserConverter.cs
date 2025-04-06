using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Converters
{
    public static class UserConverter
    {
        public static UserDto ConvertToUserDto(this User user)
        {
            return new UserDto()
            {
                UserId = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                SuspendedUntil = user.SuspendedUntil,
                AdminLevel = user.AdminLevel,
                AdminPermissionExpirationDate = user.AdminPermissionExpirationDate
            };
        }

        public static User ConvertToUser(this UserDto userDto)
        {
            return new User()
            {
                Id = userDto.UserId,
                Email = userDto.Email,
                Name = userDto.Name,
                Password = userDto.Password,
                SuspendedUntil = userDto.SuspendedUntil,
                AdminLevel = userDto.AdminLevel,
                AdminPermissionExpirationDate = userDto.AdminPermissionExpirationDate
            };
        }

        public static List<UserDto> ConvertListToUserDtos(this List<User> users)
        {
            return users.Select(ConvertToUserDto).ToList();
        }

        public static List<User> ConvertListToUsers(this List<UserDto> userDtos)
        {
            return userDtos.Select(ConvertToUser).ToList();
        }
    }
}
