using MalenkijMelo.Share.Converters;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;

namespace MalenkijMelo.Share.Assemblers
{
    public class UserSuspensionAssembler : Assembler<UserSuspension, UserSuspensionDto>
    {
        public override UserSuspensionDto ConvertToDto(UserSuspension model)
        {
            return model.ConvertToUserSuspensionDto();
        }
        public override UserSuspension ConvertToModel(UserSuspensionDto dto)
        {
            return dto.ConvertToUserSuspension();
        }
    }
}
