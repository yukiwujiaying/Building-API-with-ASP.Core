using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterest: ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetPointsOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if( city == null)
            {
                return NotFound();
            }
            // find point of interest
            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(c => c.Id == id);
            if( pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }
    }
}
