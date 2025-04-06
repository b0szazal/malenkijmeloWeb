using MalenkijMelo.Share.Converters;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Assemblers
{
    public class UserAssembler : Assembler<User, UserDto>
    {
        public override UserDto ConvertToDto(User model)
        {
            return model.ConvertToUserDto();
        }

        public override User ConvertToModel(UserDto dto)
        {
            return dto.ConvertToUser();
        }
    }
}
