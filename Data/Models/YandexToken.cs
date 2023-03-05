using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class YandexToken
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public long UserId { get; set; }
    }
}
