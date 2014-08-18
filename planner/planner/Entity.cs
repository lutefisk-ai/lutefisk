using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planner
{
    public class Entity
    {
        public Entity()
        {
            place_id = string.Empty;
            address = string.Empty;
            lat = string.Empty;
            lng = string.Empty;
            price_level = -1;
            postal_code = string.Empty;
            EntityTimings = new List<EntityTiming>();
       }
        public string place_id { get; set; }
        public string address { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public short price_level { get; set; }
        public string postal_code { get; set; }
        public List<EntityTiming> EntityTimings { get; set; }
    }

    public class EntityTiming
    {
        public short DayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    }
}
