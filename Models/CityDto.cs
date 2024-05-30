namespace CityInfoApi.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfPointOfInteres { get
            {
                return PointOfInteres.Count;
            }
            }
        public ICollection<PointOfInteresDto> PointOfInteres { get; set; }= new List<PointOfInteresDto>();

    }
}
