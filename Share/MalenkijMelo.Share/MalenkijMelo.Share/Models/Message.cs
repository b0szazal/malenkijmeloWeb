using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Models
{
    public class Message : IDbEntity<Message>
    {
        public Message()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Message(string senderId, string receiverId, string messageBody)
        {
            Id = Guid.NewGuid().ToString();
            SenderId = senderId;
            ReceiverId = receiverId;
            MessageBody = messageBody;
        }

        public string Id { get; set; } = Guid.Empty.ToString();
        public string SenderId { get; set; } = string.Concat("d", Guid.Empty.ToString());
        public string ReceiverId { get; set; } = string.Concat("d", Guid.Empty.ToString());

        public string MessageBody { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
