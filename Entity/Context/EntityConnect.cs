using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity.Context
{
    public class EntityConnect:DbContext
    {

        public EntityConnect(DbContextOptions<EntityConnect> options)
       : base(options)
        {
        }
        private readonly string _connectionString = "Host=localhost;Database=TestStady;Username=postgres;Password=1111";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public DbSet<transaction> Transactions { get; set; }
     
    }
}
