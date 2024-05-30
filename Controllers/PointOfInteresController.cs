using CityInfoApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoApi.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointofinteres")]
    public class PointOfInteresController : ControllerBase
    {

        #region Get PointsListOfCity
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
        #endregion

        #region Get PointOfCity
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
        #endregion

        #region Post PointOfCity
        [HttpPost]
        public ActionResult<PointOfInteresDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        #endregion

        #region Put UpdatePointOfInterest
        [HttpPut("{pointOfInterestId}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterestForUpdate)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=> c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }
            var point = city.PointOfInteres.FirstOrDefault(p=> p.Id == pointOfInterestId);

            if(point == null)
            {
                return NotFound();
            }
            point.Name = pointOfInterestForUpdate.Name;
            point.Description = pointOfInterestForUpdate.Description;
            return CreatedAtAction("GetPointOfCity", new { pointId = point.Id, cityId = city.Id }, point);
        }
        #endregion

        #region Patch UpdatePointOfInterest
        [HttpPatch("{pointId}")]
        public ActionResult PartiallyUpadtePointOfInterest(
            int pointId,
            int cityId,
            JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument
            ) {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city=> city.Id == pointId);
            if(city == null)
            {
                return NotFound();
            }
            var point = city.PointOfInteres.FirstOrDefault(point => point.Id == pointId);
            if(point == null)
            {
                return NotFound();
            }
            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = point.Name,
                Description = point.Description!
            };
            // check invalid input but dont send eny message 
            
            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }
            point.Name = pointOfInterestToPatch.Name;
            point.Description = pointOfInterestToPatch?.Description;

            return CreatedAtAction("GetPointOfCity", new
            {
                pointId = point.Id,
                cityId = city.Id,
            }, point);
            }
        #endregion


        #region Delete 
        [HttpDelete("{pointId}")]
        public ActionResult DeletePointOfInterest(
            int pointId,
            int cityId) {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);
            if(city == null) { return NotFound();}
            var point = city.PointOfInteres.FirstOrDefault(point=> point.Id == pointId);
            if(point == null) { return NotFound();}

            city.PointOfInteres.Remove(point);

            return Ok("the point was deleted");
        }
        #endregion
    }
}
