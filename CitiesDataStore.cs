using CityInfoApi.Models;

namespace CityInfoApi
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get; }= new CitiesDataStore();
        public CitiesDataStore() {
            Cities = new List<CityDto>()
            {
                new() { Id = 1, Name = "Qom" , Description = "small city", 
                PointOfInteres = new List<PointOfInteresDto>(){
                new PointOfInteresDto()
                {
                    Id = 1,
                    Name = "حرم حضرت معصومه",

                Description = "با صفا"
                    
                },
                new PointOfInteresDto()
                {
                    Id = 2,
                    Name = "مسجد جمکران",

                Description = "با صفا"

                },
                } },
                new() { Id = 2, Name = "Tehran" , Description = "big city",
                PointOfInteres = new List<PointOfInteresDto>(){
                new PointOfInteresDto()
                {
                    Id = 1,
                    Name = "میدان آزادی",

                Description = "با صفا"

                }
                } },
                new() { Id = 3, Name = "Yasuj" , Description = "beutiful city",
                PointOfInteres = new List<PointOfInteresDto>(){
                new PointOfInteresDto()
                {
                    Id = 1,
                    Name = "آبشار مارگون",

                Description = "با صفا"

                }
                } },
                new() { Id = 4, Name = "Shiraz" , Description = "normal city",
                PointOfInteres = new List<PointOfInteresDto>(){
                new PointOfInteresDto()
                {
                    Id = 1,
                    Name = "بازار وکیل",

                Description = "با صفا"

                }
                } },
                new() { Id = 5, Name = "Mashhad" , Description = "good city",
                PointOfInteres = new List<PointOfInteresDto>(){
                new PointOfInteresDto()
                {
                    Id = 1,
                    Name = "حرم امام رضا",

                Description = "با صفا"

                }
                } },
            };
        }
    }
}
