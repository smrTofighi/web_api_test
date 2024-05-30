using CityInfoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoApi.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointofinteres")]
    public class PointOfInteresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInteresDto>> GetPointsOfCity(int cityId)
        {
            var City = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (City == null)
            {
                return NotFound();
            }
            return Ok(City.PointOfInteres);
        }

        [HttpGet("{pointId}", Name = "GetPointOfCity")]
        public ActionResult<PointOfInteresDto> GetPointOfCity(int pointId, int cityId)
        {
            var City = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (City == null)
            {
                return NotFound();
            }
            var PointOfInterest = City.PointOfInteres.FirstOrDefault(point => point.Id == pointId);
            if (PointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(PointOfInterest);
        }
        [HttpPost]
        public ActionResult<PointOfInteresDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointOfInteres).Max(p => p.Id);
            var createPoint = new PointOfInteresDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description,
            };
            city.PointOfInteres.Add(createPoint);
            return CreatedAtAction("GetPointOfCity", new
            {
                pointId = createPoint.Id,
                cityId = cityId,
               
            },
            createPoint);
        }
    }
}
