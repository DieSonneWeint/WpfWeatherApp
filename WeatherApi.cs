using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWther
{
   public class WeatherApi : AllWeatherAPI
    {
        public string NonInformationAboutLocation { get { return $"{nonInformationAboutLocation}\nWA";} } // вывод информации о отсутствии города с инициалом API
        public Location? location { get; set; } //  название города 
        public Current? current { get; set; } // температура 
    } 

        public class Location
        {
            public string? name { get; set; }      
        }

        public class Current
        {
            public float? temp_c { get; set; }
        }
   
}
