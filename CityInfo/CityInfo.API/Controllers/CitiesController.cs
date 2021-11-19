using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Servieces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController :ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();
            //var results = new List<CityWithoutPointOfInterestDto>();
            //foreach (var cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPointOfInterestDto
            //    {
            //        Id = cityEntity.Id,
            //        Description = cityEntity.Description,
            //        Name = cityEntity.Name
            //    });
            //}
            //return Ok(results);

            //return more than one city so use ienumerable
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityEntities));
        }


        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointOfInterest= false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointOfInterest);
            if (city== null)
            {
                return NotFound();
            }
            if (includePointOfInterest)
            {
                var cityResult = _mapper.Map<CityDto>(city);
                return Ok(cityResult);
            }
            var cityWithoutPointOfInterestResult = _mapper.Map<CityWithoutPointOfInterestDto>(city);

            return Ok(cityWithoutPointOfInterestResult);
        }
    }
}
