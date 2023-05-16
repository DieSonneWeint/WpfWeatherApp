using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWther
{
    public class VisCrossWeather : AllWeatherAPI
    {
        public string NonInformationAboutLocation { get { return $"{nonInformationAboutLocation}\nVCW"; } }
        public string? address { get; set; }
        public Day[]? days { get; set; }
       
    }

        public class Day
        {         
            public float? temp { get; set; }
                  
        }
 
}
