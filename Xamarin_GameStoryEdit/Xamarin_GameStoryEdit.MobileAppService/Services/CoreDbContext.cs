using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin_GameStoryEdit.Models;

namespace Xamarin_GameStoryEdit.MobileAppService.Services
{
    public class CoreDbContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(@"Server=XX.XX.XX.XX;port=XXXX;DataBase=XXXX;User ID=XXXX;password=XXXX;SslMode=XXXX");
            }
        }
    }
}
