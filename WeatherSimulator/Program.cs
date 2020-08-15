using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherSimulator weatherSimulator = new WeatherSimulator(1000);
            Statistician statistician = new Statistician(weatherSimulator);
            statistician.StartAnalysis();
            statistician.DisplayReport();
        }
    }
}
