using System.Collections.Generic;
using System.Windows;

namespace CV19.Models
{
    //Модель базового класса
    internal class PlaceInfo
    {
        public string Name { get; set; }

        public Point Locatio { get; set; }

        public IEnumerable<ConfirmedCount> Counts { get; set; }
    }
}
