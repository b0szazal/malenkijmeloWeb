using MalenkijMelo.Share.Converters;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;

namespace MalenkijMelo.Share.Assemblers
{
    public class AdminActionAssembler : Assembler<AdminAction, AdminActionDto>
    {
        public override AdminActionDto ConvertToDto(AdminAction model)
        {
            return model.ConvertToAdminActionDto();
        }

        public override AdminAction ConvertToModel(AdminActionDto dto)
        {
            return dto.ConvertToAdminAction();
        }
    }
}
