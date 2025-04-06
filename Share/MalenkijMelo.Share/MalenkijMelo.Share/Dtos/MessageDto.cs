using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Dtos
{
    public class MessageDto
    {
        public string MessageId { get; set; } = Guid.Empty.ToString();
        public string SenderId { get; set; } = string.Concat("d", Guid.Empty.ToString());
        public string ReceiverId { get; set; } = string.Concat("d", Guid.Empty.ToString());

        public string MessageBody { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
