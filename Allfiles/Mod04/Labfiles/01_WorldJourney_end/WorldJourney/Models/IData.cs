using System.Collections.Generic;

namespace WorldJourney.Models
{
    public interface IData
    {
        IList<City> CityList { get; set; }
        IList<City> CityInitializeData();
        City GetCityById(int? id);
    }
}
