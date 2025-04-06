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
    public class WorkplaceAssembler : Assembler<Workplace, WorkplaceDto>
    {
        public override WorkplaceDto ConvertToDto(Workplace model)
        {
            return model.ConvertToWorkplaceDto();
        }

        public override Workplace ConvertToModel(WorkplaceDto dto)
        {
            return dto.ConvertToUserJobAction();
        }
    }
}
