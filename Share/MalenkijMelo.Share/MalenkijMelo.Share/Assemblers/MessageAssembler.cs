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
    public class MessageAssembler : Assembler<Message, MessageDto>
    {
        public override MessageDto ConvertToDto(Message model)
        {
            return model.ConvertToMessageDto();
        }

        public override Message ConvertToModel(MessageDto dto)
        {
            return dto.ConvertToMessage();
        }
    }
}
