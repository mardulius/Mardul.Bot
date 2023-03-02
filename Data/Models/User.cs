using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        public long Id { get; set; }
        public long TelegramUserId { get; set; }
        public long ChatId { get; set; }
        public string Name { get; set; }


    }
}
