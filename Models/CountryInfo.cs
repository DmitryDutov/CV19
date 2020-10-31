using System.Collections.Generic;

namespace CV19.Models
{
    //Модель информации о стране
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
