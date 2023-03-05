using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BotContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<YandexToken> YandexTokens { get; set; }

        public BotContext(DbContextOptions<BotContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
