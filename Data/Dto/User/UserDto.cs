using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto.User
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long YandexTokenId { get; set; }
        public string YandexToken { get; set; }
    }
}
