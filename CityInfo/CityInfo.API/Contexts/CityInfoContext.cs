﻿using CityInfo.API.Entities;
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
            //Database.EnsureCreated();
        }


        ////another way of having connection string 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //tell the dbcontext to connect to sql server
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                 .HasData(
                new City()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park."
                },
                new City()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished."
                },
                new City()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower."
                });


            modelBuilder.Entity<PointOfInterest>()
              .HasData(
                new PointOfInterest()
                {
                    Id = 1,
                    CityId = 1,
                    Name = "Central Park",
                    Description = "The most visited urban park in the United States."

                },
                new PointOfInterest()
                {
                    Id = 2,
                    CityId = 1,
                    Name = "Empire State Building",
                    Description = "A 102-story skyscraper located in Midtown Manhattan."
                },
                  new PointOfInterest()
                  {
                      Id = 3,
                      CityId = 2,
                      Name = "Cathedral",
                      Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                  },
                new PointOfInterest()
                {
                    Id = 4,
                    CityId = 2,
                    Name = "Antwerp Central Station",
                    Description = "The the finest example of railway architecture in Belgium."
                },
                new PointOfInterest()
                {
                    Id = 5,
                    CityId = 3,
                    Name = "Eiffel Tower",
                    Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                },
                new PointOfInterest()
                {
                    Id = 6,
                    CityId = 3,
                    Name = "The Louvre",
                    Description = "The world's largest museum."
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
