using Microsoft.Win32;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using OxyPlot.Wpf;
using OxyPlot.Axes;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace WpfAppWther
{
    public class ModelV
    {
        Model model = new Model(); 
        HttpClient client = new HttpClient();

        string API = "d3b601a5292fe7374e161205cf54ca0f";
        string API2 = "E8PDDNGUQTG972373HU9DKM4U";
        string API3 = "9267ce2ca31d4d50861102445232401";
        string URI, URI2, URI3, URI4;

        private void CreateURI(string CityName) // создание Uri
        {
            URI = $"https://api.openweathermap.org/data/2.5/weather?q={CityName}&appid=d3b601a5292fe7374e161205cf54ca0f&units=metric";
            URI2 = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{CityName}/today?unitGroup=metric&key=E8PDDNGUQTG972373HU9DKM4U&contentType=json";
            URI3 = $"http://api.weatherapi.com/v1/current.json?key=9267ce2ca31d4d50861102445232401&q={CityName}&aqi=no";
            URI4 = $"http://api.weatherstack.com/current?access_key=3d339b07eb46691e2bdb4b0e056d4cb8&query={CityName}";
        }
        public async void ResponseMessage(string CityName) // Сбор данных Api
        {
            model = new Model();
            CreateURI(CityName);
            HttpResponseMessage httpResponseMessage = await client.GetAsync(URI);
            HttpResponseMessage httpResponseMessage2 = await client.GetAsync(URI2);
            HttpResponseMessage httpResponseMessage3 = await client.GetAsync(URI3);
            HttpResponseMessage httpResponseMessage4 = await client.GetAsync(URI4);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                model.AllWeatherAP.openWeather = await httpResponseMessage.Content.ReadFromJsonAsync<OpenWeather>();
            }
            if (httpResponseMessage2.IsSuccessStatusCode)
            {
                model.AllWeatherAP.visCross = await httpResponseMessage2.Content.ReadFromJsonAsync<VisCrossWeather>();
            }

            if (httpResponseMessage3.IsSuccessStatusCode)
            {
                model.AllWeatherAP.weatherapi = await httpResponseMessage3.Content.ReadFromJsonAsync<WeatherApi>();
            }

            if (httpResponseMessage4.IsSuccessStatusCode)
            {
                model.AllWeatherAP.weatherstack = await httpResponseMessage4.Content.ReadFromJsonAsync<Weatherstack>();
            }

            model.AllWeatherAP.date = DateTime.Now;
        }

        public PlotModel PlotConst() // функция для построения графиков 
        {
            var x = 0;
            var plotModel = new PlotModel { Title = $"{model.AllWeatherAP.visCross.address}" };
            var series = new LineSeries();


            CheckDate();

            // Добавляем точки в серию данных
            for (int i = 0; i < model.GrafConst.midTemp.Count; i++)
            {
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(model.GrafConst.dates[i]), model.GrafConst.midTemp[i]));
            }



            // Устанавливаем подписи осей
            plotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, Title = "Дата" });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Температура" });



            plotModel.Series.Add(series);
            return plotModel;
        }

        private bool CheckDate() // проверка для значений графика 
        {
            if (model.GrafConst.dates == null)
            {
                model.GrafConst.dates.Add(model.AllWeatherAP.date);
                model.GrafConst.midTemp.Add(double.Parse(ReturnAverageTemp()));
                return true;
            }
            int i = 0;
            foreach ( DateTime? date in model.GrafConst.dates)
            {
                if (date ==  model.AllWeatherAP.date) 
                return false;
                if (date > model.AllWeatherAP.date)
                {
                    model.GrafConst.dates.Insert(i, model.AllWeatherAP.date);
                    model.GrafConst.midTemp.Insert(i, double.Parse(ReturnAverageTemp()));
                    return true;
                }

            }
            model.GrafConst.dates.Add(model.AllWeatherAP.date);
            model.GrafConst.midTemp.Add(double.Parse(ReturnAverageTemp()));
            return true;
        }

    public void Save(int number,string FileName) // сохранение
        {
            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate);
            switch (number)
            {
                case 0: model.Save(file,model.AllWeatherAP); break;
                case 1: model.Save(file,model.GrafConst); break;
            }
        }
    
    private bool CheckCity() // проверка на наличие города 
        {
            if (model.AllWeatherAP.openWeather.name == null || model.AllWeatherAP.visCross.address == null || model.AllWeatherAP.weatherapi.location == null || model.AllWeatherAP.weatherstack.Location == null)
                    return false;
            return true;
        }

    public void Load(int number,string FileName)// загрузка
        {
            FileStream file = File.OpenRead(FileName);
            switch (number)
            {
                case 0: model.Load(file, model.AllWeatherAP); break;
                case 1: model.Load(file, model.GrafConst); break;
            }
        }    
        public string? ReturnTempOpenWeather() // возвращает значение температуры OpenWeather 
        {
            if (CheckCity())
             return $"{Math.Round(Convert.ToDouble(model.AllWeatherAP.openWeather.main.temp),2)}";
            return "-";
        }
        public string? ReturnCityNameOpenWeather() // возвращает название города OpenWeather
        {
            if (CheckCity())
                return model.AllWeatherAP.openWeather.name;
            return model.AllWeatherAP.openWeather.NonInformationAboutLocation;
        }
        public string? ReturnTempVissCrossWeather() // возвращает температуру VissCrossWeather
        {
            if (CheckCity())
                return $"{Math.Round(Convert.ToDouble(model.AllWeatherAP.visCross.days[0].temp),2)}";
            return "-";
        }
        public string? ReturnCityNameVissCross() // возвращает название города VissCrossWeather
        {
            if (CheckCity())
                return model.AllWeatherAP.visCross.address;
            return model.AllWeatherAP.visCross.NonInformationAboutLocation;
        }
        public string? ReturnTempWeatherApi() // возвращает название температуры WeatherApi
        {
            if (CheckCity())
                return $"{Math.Round(Convert.ToDouble(model.AllWeatherAP.weatherapi.current.temp_c),2)}";
            return "-";
        }
        public string? ReturnCityNameWeatherApi() // возвращает название города WeatherApi
        {
            if (CheckCity())
                return model.AllWeatherAP.weatherapi.location.name;
            return model.AllWeatherAP.weatherapi.NonInformationAboutLocation;
        }
        public string? ReturnTempWeatherStack() // возвращает  температуры WeatherStack
        {
            if (CheckCity())
                if(model.AllWeatherAP.weatherstack.Current != null)
                return $"{Math.Round(Convert.ToDouble(model.AllWeatherAP.weatherstack.Current.temperature),2)}";
            return "-";
        }
        public string? ReturnCityNameWeatherStack() // возвращает название города WeatherStack
        {
           if (CheckCity())
                return model.AllWeatherAP.weatherstack.Location.name;
            return model.AllWeatherAP.weatherstack.NonInformationAboutLocation;
        }

        public string ReturnAverageTemp() // подсчет средней температуры
        {
            int del = 0;
            double? result = null;
            if (ReturnTempVissCrossWeather() != "-")
            {
                del++;
                result = Convert.ToDouble(ReturnTempVissCrossWeather());
            }

            if (ReturnTempWeatherApi() != "-")
            {
                del++;
                result += Convert.ToDouble(ReturnTempWeatherApi());
            }
            if (ReturnTempOpenWeather() != "-")
            {
                del++;
                result += Convert.ToDouble(ReturnTempOpenWeather());
            }
            if (ReturnTempWeatherStack() != "-")
            {
                del++;
                result += Convert.ToDouble(ReturnTempWeatherStack());
            }
            if (result != null)
            {
                return $"{Math.Round(Convert.ToDouble(result / del), 2)}";
            }
            return "-";
        }
    }
}
