using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppWther;

namespace WpfWeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ModelV model = new ModelV();
        public MainWindow()
        {
            InitializeComponent();
            TextBoxC.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            if (File.Exists("WeatherTemp.json"))
            {
                model.Load(0, "WeatherTemp.json");
                labelprint();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            if (TextBoxC.Text != "")
            {
                Button.IsEnabled = false;
                try
                {
                    model.ResponseMessage(TextBoxC.Text);
                }
                catch (InvalidOperationException ex)
                {
                    LabelEx.Content = ex.Message;
                }
                catch (HttpRequestException ex)
                {
                    LabelEx.Content = ex.Message;
                }
                catch (TaskCanceledException ex)
                {
                    LabelEx.Content = ex.Message;
                }
                catch (JsonException ex)
                {
                    LabelEx.Content = ex.Message;
                }
                await Task.Delay(3000);
                labelprint();
                if (model.ReturnAverageTemp() != "-")
                {
                    model.Save(0, "WeatherTemp.json");
                    model.Save(0, $"SaveData\\{System.DateTime.Now.ToShortDateString()}_{model.ReturnCityNameVissCross()}.json");
                }
                TextBoxC.Text = "";
                Button.IsEnabled = true;
            }
        }
        private void labelprint()
        {
            LabelOpenWeat.Content = $"OpenWeath\n{model.ReturnCityNameOpenWeather()}\n{model.ReturnTempOpenWeather()}  C";
            LabelWeatherApi.Content = $"WeatherApi\n{model.ReturnCityNameWeatherApi()}\n{model.ReturnTempWeatherApi()}  C";
            LabelVisualCros.Content = $"VisualCross\n{model.ReturnCityNameVissCross()}\n{model.ReturnTempVissCrossWeather()}  C";
            LabelWeatherStack.Content = $"WeatherStack\n{model.ReturnCityNameWeatherStack()}\n{model.ReturnTempWeatherStack()}  C";
            AverageTemp.Content = $"Средняя температура\n {model.ReturnAverageTemp()} C";
        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ButtonLoad.IsEnabled = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"Weather\bin\Debug\net6.0-windows\SaveData\\";
            openFileDialog.Filter = "json files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                model.Load(0, openFileDialog.FileName);
            }
            labelprint();
            ButtonLoad.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (model.ReturnAverageTemp() != "-")
            {
                GrafButton.IsEnabled = false;
                if (File.Exists($"GraficsData\\{model.ReturnCityNameVissCross()}.json"))
                { model.Load(1, $"GraficsData\\{model.ReturnCityNameVissCross()}.json"); }
                Window window = new Plot(model);
                window.Closed += Window_Closed;
                window.Show();
            }
        }
  
        private void Window_Closed(object? sender, EventArgs e)
        {
            GrafButton.IsEnabled = true;
            model.Save(1, $"GraficsData\\{model.ReturnCityNameVissCross()}.json");
        }
    }
}

