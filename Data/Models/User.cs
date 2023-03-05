
using System;

namespace Data.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public long TokenId { get; set; }
    }
}
