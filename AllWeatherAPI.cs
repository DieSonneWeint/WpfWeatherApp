using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWther
{
    public class AllWeatherAPI
    {
        public DateTime date { get; set; } // дата 

        public string nonInformationAboutLocation = "Город не найден"; 

        public OpenWeather? openWeather { get; set; } 
        public Weatherstack? weatherstack { get; set; } 
        public WeatherApi? weatherapi { get; set; } 
        public VisCrossWeather? visCross { get; set; } 
    }
}
