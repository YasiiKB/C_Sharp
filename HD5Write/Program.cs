// Example from https://www.nuget.org/packages/HDF5-CSharp
// Install HDF5-CSharp from NuGet Package Manager or 'dotnet add package HDF5-CSharp --version 1.19.0'
// This code creates a HDF5 file and writes an object to it
using HDF5CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HD5Write
{
    class TestClass
    {
        public double[] TestDoubles { get; set; }
        public string[] TestStrings { get; set; }
        public int TestInteger { get; set; }
        public double TestDouble { get; set; }
        public bool TestBoolean { get; set; }
        public string TestString { get; set; }
        public double[] TestReals { get; set; }
        public double[] TestImaginaries { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of TestClass
            var testClass = new TestClass
            {
                TestInteger = 2,
                TestDouble = 1.1,
                TestBoolean = true,
                TestString = "test string",
                TestDoubles = new double[] { 1.1, 1.2, -1.1, -1.2 },
                TestStrings = new string[] { "one", "two", "three", "four" },
                TestReals = new double[] { 5.6222, 9.575753, 10 },
                TestImaginaries = new double[] { -13242, 0.6243, -2.95353 }
            };

            // Create a HDF5 file
            string myPath = "C:\\Users\\stude\\Desktop\\Learning\\HD5Write\\";
            string filename = Path.Combine(myPath, "anothertestFile.H5");
            long fileId = Hdf5.CreateFile(filename);

            // Write the object to the file
            Hdf5.WriteObject(fileId, testClass, "testObject");

            // Close the file
            Hdf5.CloseFile(fileId);

            Console.WriteLine("File Created!");
        }
    }
}