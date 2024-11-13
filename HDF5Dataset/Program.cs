// Example from https://www.nuget.org/packages/HDF5-CSharp
// Install HDF5-CSharp: 'dotnet add package HDF5-CSharp --version 1.19.0'
// This code creates a HDF5 file and writes an object to it

using HDF5CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HD5Dataset
{
    class Program
    {

        /// <summary>
        /// Create a matrix and fill it with numbers
        /// </summary>
        /// <param name="offset"></param>
        /// <returns>The matrix</returns>
        private static double[,] createDataset(int offset = 0)
        {
            var dset = new double[10, 5];
            for (var i = 0; i < 10; i++)
                for (var j = 0; j < 5; j++)
                {
                    double x = i + j * 5 + offset;
                    dset[i, j] = (j == 0) ? x : x / 10;
                }
            return dset;
        }

        /// <summary>
        /// Print the matrix to the console
        /// </summary>
        /// <param name="matrix">The matrix to print</param>
        private static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {

            // Create a list of matrices
            var dsets = new List<double[,]>
        {
            createDataset(),
            createDataset(10),
            createDataset(20)
        };

            string myPath = "C:\\Users\\stude\\Desktop\\Learning\\HDF5Dataset";
            string filename = Path.Combine(myPath, "testChunks.H5");
            long fileId = Hdf5.CreateFile(filename);

            // Create a dataset and append two more datasets to it
            using (var chunkedDset = new ChunkedDataset<double>("/test", fileId, dsets.First()))
            {
                foreach (var ds in dsets.Skip(1))
                    chunkedDset.AppendDataset(ds);
            }

            // Read rows 9 to 22 of the dataset
            ulong begIndex = 8;
            ulong endIndex = 21;
            var dset = Hdf5.ReadDataset<double>(fileId, "/test", begIndex, endIndex);
            Hdf5.CloseFile(fileId);

            // Print the dataset
            PrintMatrix(dset);

            Console.WriteLine("Chunked dataset created and subset read!");
        }
    }
}


