using CityInfoApi.Entities;

namespace CityInfoApi.Repositories
{
    public interface ICityInfoRepository
    {
       Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityAsync(int cityId, bool incloudePointOfInterest);
        Task<IEnumerable<PointOfInterest>> GetPointOfInterestsForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestOfCityAsync(int cityId, int pointId); 
    }
}
