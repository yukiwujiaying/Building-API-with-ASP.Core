using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Servieces
{
    public interface ICityInfoRepository
    {
        //if return IQueryable,the consumer of the repository can keep on building on that Iqueryable
        //for example, they can add oderby clause, a where clause, etc.
        IEnumerable<City> GetCities();

        City GetCity(int cityId,  bool includePointOfInterest);

        IEnumerable<PointOfInterest> GetPointsOfInterestforCity(int cityId);

        //only get one point of interest of city
        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);
        bool CityExists(int cityId);

        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);

        void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);

        void DeletePointOfInterest(PointOfInterest pointOfInterest);

        bool Save();
    }
}
