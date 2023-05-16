using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WpfAppWther
{
    internal class Model
    {
        public AllWeatherAPI AllWeatherAP = new AllWeatherAPI() {visCross =new VisCrossWeather(), openWeather = new OpenWeather(), weatherapi = new WeatherApi(), weatherstack = new Weatherstack()}; // хранит информацию о всех источника погоды 

        public GrafConst GrafConst = new GrafConst() { midTemp = new List<double>() , dates = new List<DateTime>()}; // хранит информацию о графиках 
        public  void Load (FileStream fileStream, AllWeatherAPI allWeatherAPI) // загрузка информации о погоде
        {           
            AllWeatherAP=JsonSerializer.Deserialize<AllWeatherAPI>(fileStream);
            fileStream.Close();
         
        }
        public void Load(FileStream fileStream, GrafConst grafConst) // загрузка информации для графиков
        {            
            GrafConst = JsonSerializer.Deserialize<GrafConst>(fileStream);
            fileStream.Close();

        }
        public async void Save(FileStream fileStream,AllWeatherAPI allWeatherAPI) // сохранение информации о погоде
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            await JsonSerializer.SerializeAsync(fileStream, allWeatherAPI, options);
            await fileStream.DisposeAsync();
        }
        public async void Save(FileStream fileStream, GrafConst grafConst) // сохранение информации для графиков 
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            await JsonSerializer.SerializeAsync(fileStream, grafConst, options);
            await fileStream.DisposeAsync();
        }
    }
}
