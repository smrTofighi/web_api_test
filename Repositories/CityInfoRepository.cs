using CityInfoApi.DBContext;
using CityInfoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfoApi.Repositories
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoDBContext _context;
        public CityInfoRepository(CityInfoDBContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
    

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
         return await _context.Cities.OrderBy(city=> city.Name).ToListAsync();
        }

       async public Task<City?> GetCityAsync(int cityId, bool incloudePointOfInterest)
        {
            if (incloudePointOfInterest)
            {
                return await _context.Cities.Include(c => c.PointOfInterests).Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }
            return await _context.Cities.Where(c=> c.Id == cityId).FirstOrDefaultAsync();
        }

     async public   Task<PointOfInterest?> GetPointOfInterestOfCityAsync(int cityId, int pointId)
        {
        
            return await _context.PointOfInterests.Where(p=> p.CityId == cityId && p.Id == pointId ).FirstOrDefaultAsync();
        }

       async public Task<IEnumerable<PointOfInterest>> GetPointOfInterestsForCityAsync(int cityId)
        {
            return await _context.PointOfInterests.Where(p => p.CityId == cityId).ToListAsync();
        }
    }
}
