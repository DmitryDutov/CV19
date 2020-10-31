using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CV19.Models
{
    internal class Country
    {
        public string Name { get; set; }

        public Point Locatio { get; set; }

        public IEnumerable<ConfirmedCount> Counts { get; set; }
    }

    internal struct ConfirmedCount
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}
