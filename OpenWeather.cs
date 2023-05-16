using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWther
{
    public class OpenWeather : AllWeatherAPI
    {
        public string NonInformationAboutLocation { get { return $"{nonInformationAboutLocation}\nOW"; } } // вывод информации о отсутствии города с инициалом API
        public Main? main { get; set; } // температура
        public string? name { get; set; } // название города 

    }
}
