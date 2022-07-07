using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Model;

namespace Server.Data
{
    public class ServerContext : DbContext
    {
        public ServerContext (DbContextOptions<ServerContext> options)
            : base(options)
        {
        }

        public DbSet<Server.Model.TblUsers> TblUsers { get; set; }

        public DbSet<Server.Model.TblGames> TblGames { get; set; }
    }
}
