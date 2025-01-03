﻿// based on this page: https://planetcalc.com/7899/ and https://statisticsbyjim.com/time-series/moving-averages-smoothing/

using System;

namespace CenteredMA
{
    class Program
    {
        static void Main()
        {
            // Dummy data
            var dummy_data = new List<double> { 100, 120, 150, 180, 200, 220, 210, 250, 260, 240, 220, 210 };
            int win_size = 3;  // user input

            // Ramdomly remove some data points
            int RandomRemoveCount = 0; // user input
            Random rnd = new Random();
            for (int i = 0; i < Math.Min(dummy_data.Count, RandomRemoveCount); i++)
            {
                dummy_data.RemoveAt(rnd.Next(dummy_data.Count));
            }

            Console.WriteLine("Data Length after: " + dummy_data.Count);

            // Calculate the centered moving average for window size
            double[] cma = CalculateCenteredMovingAverage(dummy_data, win_size);

            // Output the results
            //Console.WriteLine("Index  Data      Centered Moving Average");
            //for (int i = 0; i < dummy_data.Count; i++)
            //{
            //    Console.WriteLine($"{i + 1,5}  {dummy_data[i],5}  {cma[i],25:F2}");
            //}
            for (int i = win_size/2; i < cma.Length - win_size/2; i++)  // to exclude the data points that are not enough for the window size
            {
                Console.WriteLine(cma[i]);
            }
        }

        // Function to calculate the centered moving average for a given window size
        static double[] CalculateCenteredMovingAverage(List<double> data, int windowSize)
        {
            int dataLength = data.Count;
            double[] cma = new double[dataLength];

            // For Even window size
            if (windowSize % 2 == 0)
            {
                windowSize = windowSize - 1; // to make it odd
            }
            int halfWindow = windowSize / 2;

            for (int i = 0; i < dataLength; i++)
            {
                int start = Math.Max(i - halfWindow, 0);            // To avoid negative values
                int end = Math.Min(i + halfWindow, dataLength - 1); // To avoid "out of bounds" error
                int count = end - start + 1;
                double sum = 0;

                // Sum the values in the window
                for (int j = start; j <= end; j++)
                {
                    sum += data[j];
                }

                // Calculate the centered moving average for the current point
                cma[i] = sum / count;
            }
            return cma;
        }
    }
}
