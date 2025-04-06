using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Converters
{
    public static class MessageConverter
    {
        public static MessageDto ConvertToMessageDto(this Message message)
        {
            return new MessageDto()
            {
                MessageBody = message.MessageBody,
                ReceiverId = message.ReceiverId,
                SenderId = message.SenderId,
                Date=message.Date,
                MessageId = message.Id,
            };
        }

        public static Message ConvertToMessage(this MessageDto messageDto)
        {
            return new Message()
            {
                MessageBody = messageDto.MessageBody,
                ReceiverId = messageDto.ReceiverId,
                SenderId = messageDto.SenderId,
                Date = messageDto.Date,
                Id = messageDto.MessageId,
            };
        }

        public static List<MessageDto> ConvertListToMessageDtos(this List<Message> messages)
        {
            return messages.Select(ConvertToMessageDto).ToList();
        }

        public static List<Message> ConvertListToMessages(this List<MessageDto> messageDtos)
        {
            return messageDtos.Select(ConvertToMessage).ToList();
        }
    }
}
