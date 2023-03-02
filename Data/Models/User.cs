
using System;

namespace Data.Models
{
    public class User
    {
        public long Id { get; set; }
        public long TelegramUserId { get; set; }
        public long ChatId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
