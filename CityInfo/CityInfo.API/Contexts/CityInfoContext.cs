using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Contexts
{
    public class CityInfoContext : DbContext
    {
        //Dbset can be used to query and save instances of its entity type
        //link queries against the Dbset will be translated into queries against the database
        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterests { get; set; }

        //this is the constructor that allow the config to use the onnection string
        public CityInfoContext(DbContextOptions<CityInfoContext> options):base(options)
        {
            Database.EnsureCreated();
        }


        ////another way of having connection string 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //tell the dbcontext to connect to sql server
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
