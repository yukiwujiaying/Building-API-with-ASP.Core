﻿using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Servieces
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c=>c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Include(c => c.PointOfInterests).Where(c => c.Id == cityId).FirstOrDefault();
            }

            return _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointOfInterests.Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointOfInterestforCity(int cityId)
        {
            return _context.PointOfInterests.Where(p => p.CityId == cityId).ToList();
        }

        
    }
}
