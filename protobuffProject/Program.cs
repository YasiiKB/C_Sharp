using System;
using System.IO;
//using System.Numerics.Complex; // For Complex type
using ProtoBuf; // For protobuf serialization
using NoiseCalMeas;

namespace NoiseCalMeas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of noisecalmeas with dummy values
            meaurements NoiseCalMeas = new meaurements
            {
                freqs = new double[] { 1000, 2000, 3000 }, // Dummy frequencies in Hz
                number_of_gammas = 2, // Example: 2 gamma positions
                enr = new double[] { 10, 12, 14 }, // Example ENR values
                //GammaNSHot = new Complex[]
                //{
                //    new Complex(0.5, 0.1), new Complex(0.6, 0.2), new Complex(0.7, 0.3) // Hot state gamma
                //},
                //GammaNSCold = new Complex[]
                //{
                //    new Complex(0.2, 0.05), new Complex(0.3, 0.07), new Complex(0.4, 0.09) // Cold state gamma
                //}
            };

            // Serialize the object to a protobuf file
            string filePath = "noiseCalMeasData.bin";
            using (FileStream file = File.Create(filePath))
            {
                Serializer.Serialize(file, noiseCalMeas);
                Console.WriteLine($"Data successfully serialized to {filePath}");
            }

            // Deserialize the object from the protobuf file
            using (FileStream file = File.OpenRead(filePath))
            {
                NoiseCalMeas deserializedData = Serializer.Deserialize<NoiseCalMeas>(file);
                Console.WriteLine("Data successfully deserialized:");

                // Print out the deserialized data
                Console.WriteLine("Frequencies: " + string.Join(", ", deserializedData.Freqs));
                Console.WriteLine("Number of Gammas: " + deserializedData.NumberOfGammas);
                Console.WriteLine("ENR: " + string.Join(", ", deserializedData.ENR));

                //Console.WriteLine("GammaNSHot:");
                //foreach (var gamma in deserializedData.GammaNSHot)
                //{
                //    Console.WriteLine(gamma);
                //}

                //Console.WriteLine("GammaNSCold:");
                //foreach (var gamma in deserializedData.GammaNSCold)
                //{
                //    Console.WriteLine(gamma);
                //}
            }
        }
    }
}
