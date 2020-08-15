using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeatherSimulator
{
    public class WeatherSimulator
    {
        private Weather? lastWeather;
        private int numberOfRepetition;
        private Random random;
        public event Action<Weather> WeatherAlert;

        public WeatherSimulator(int number)
        {
            random = new Random();
            lastWeather = null;
            numberOfRepetition = number;
        }

        public void Start()
        {
            for(int i = 0; i < numberOfRepetition; i++)
            {
                int value = random.Next(0, 100);
                if(value < 5)
                {
                    ManageWeather(Weather.Sunny);
                }
                else
                {
                    if (value < 50)
                        ManageWeather(Weather.Cloudy);
                    else
                    {
                        if (value < 90)
                            ManageWeather(Weather.Rainy);
                        else
                            ManageWeather(Weather.Stormy);
                    }
                }
            }
        }

        private void ManageWeather(Weather newWeather)
        {
            if (lastWeather.HasValue && lastWeather.Value != newWeather && WeatherAlert != null)
                WeatherAlert(newWeather);
            lastWeather = newWeather;
        }
    }
}
