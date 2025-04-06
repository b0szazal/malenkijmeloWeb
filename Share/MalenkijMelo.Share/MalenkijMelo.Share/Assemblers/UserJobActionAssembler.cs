using MalenkijMelo.Share.Converters;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;

namespace MalenkijMelo.Share.Assemblers
{
    public class UserJobActionAssembler : Assembler<UserJobAction, UserJobActionDto>
    {
        public override UserJobActionDto ConvertToDto(UserJobAction model)
        {
            return model.ConvertToUserJobActionDto();
        }

        public override UserJobAction ConvertToModel(UserJobActionDto dto)
        {
            return dto.ConvertToUserJobAction();
        }
    }
}
