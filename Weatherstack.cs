using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWther
{
    public class Weatherstack : AllWeatherAPI
    {
        public string NonInformationAboutLocation { get { return $"{nonInformationAboutLocation}\nWS"; } } // вывод информации о отсутствии города с инициалом API
        public Locations? Location { get; set; } // название города 
        public Currents? Current { get; set; } // температура 

    }


    public class Locations
    {
        public string? name { get; set; }
    }

    public class Currents
    {
        public int? temperature { get; set; } 
    }

}