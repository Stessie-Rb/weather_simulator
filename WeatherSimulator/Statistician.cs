using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    public class Statistician
    {
        private WeatherSimulator weatherSimulator;
        private int nbTimesTheWeatherChanges;
        private int nbTimesItIsSunny;

        public Statistician(WeatherSimulator wSimulator)
        {
            weatherSimulator = wSimulator;
            nbTimesTheWeatherChanges = 0;
            nbTimesItIsSunny = 0;
        }

        public void StartAnalysis()
        {
            nbTimesTheWeatherChanges = 0;
            nbTimesItIsSunny = 0;
            weatherSimulator.WeatherAlert += weatherSimulator_WeatherAlert;
            weatherSimulator.Start();
            weatherSimulator.WeatherAlert -= weatherSimulator_WeatherAlert;
        }

        public void DisplayReport()
        {
            Console.WriteLine("Number of times the weather has changed : " + nbTimesTheWeatherChanges);
            Console.WriteLine("Number of times it was sunny: " + nbTimesItIsSunny);
            Console.WriteLine("Percentage of good weather: " + nbTimesItIsSunny * 100 / nbTimesTheWeatherChanges + " %");
        }

        private void weatherSimulator_WeatherAlert(Weather weather)
        {
            if (weather == Weather.Sunny)
                nbTimesItIsSunny++;
            nbTimesTheWeatherChanges++;
        }
    }
}
