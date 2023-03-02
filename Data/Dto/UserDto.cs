using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public long TelegramUserId { get; set; }
        public string Name { get; set; }
        public long ChatId { get; set; }
    }
}
