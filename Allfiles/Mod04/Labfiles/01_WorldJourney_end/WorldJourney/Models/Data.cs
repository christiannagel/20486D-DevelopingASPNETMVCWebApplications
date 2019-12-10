using System.Collections.Generic;
using System.Linq;

namespace WorldJourney.Models
{
    public class Data : IData
    {
        public IList<City> CityList { get; set; }

        public IList<City> CityInitializeData()
        {
            CityList = new List<City>()
            {
                new City {ID = 1,CityName = "New York",ImageName = "new-york.jpg",ImageMimeType = "image/jpeg"},
                new City {ID = 2,CityName = "London",ImageName = "london.jpg",ImageMimeType = "image/jpeg"},
                new City {ID = 3,CityName = "Chicago",ImageName = "chicago.jpg", ImageMimeType = "image/jpeg"}
            };
            return CityList;
        }

        public City GetCityById(int? id)
            => id == null ? null : CityList.SingleOrDefault(a => a.ID == id);
    }
}
