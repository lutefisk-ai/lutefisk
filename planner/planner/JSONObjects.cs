using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planner
{
    public class GooglePlaces
    {
        public Row[] results { get; set; }
        public string status { get; set; }
    }

    public class GooglePlace
    {
        public Row result { get; set; }
        public string status { get; set; }
    }

    public class Location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
    }

    public class OpeningHours
    {
        public bool open_now { get; set; }
        public Period[] periods { get; set; }
    }

    public class Period
    {
        public Timing open { get; set; }
        public Timing close { get; set; }
    }

    public class Timing
    {
        public short day { get; set; }
        public string time { get; set; }
    }

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }

    public class Row
    {
        public string place_id { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string price_level { get; set; }
        public OpeningHours opening_hours { get; set; }
        public AddressComponent[] address_components { get; set; }
    }
}
