// A file to write data to an HDF5 file using PureHDF 
// Install: dotnet add package PureHDF --version 2.1.1

using PureHDF;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a new HDF5 file   
        var file = new H5File()
        {
            // Create a group
            ["my-group"] = new H5Group()
            {
                // Add datasets to the group 
                ["numerical-dataset"] = new double[] { 2.0, 3.1, 4.2 },
                ["string-dataset"] = new string[] { "One", "Two", "Three" },

                // Add attributes to the group (Attributes cannot be added directly)
                Attributes = new()
                {
                    ["numerical-attribute"] = new double[] { 2.0, 3.1, 4.2 },
                    ["string-attribute"] = new string[] { "One", "Two", "Three" }
                }
            }
        };

        //path 
        string myPath = "C:\\Users\\stude\\Desktop\\Learning\\PureHDF\\Writing\\";
        string filename = Path.Combine(myPath, "anothertestFile.h5");

        // Write to file
        file.Write(filename);
        Console.WriteLine("Data written to HDF5 file successfully.");


        // Open the HDF5 file for reading
        var Rfile = H5File.OpenRead(filename);

        // Access the group
        var group = Rfile.Group("my-group");


        // Read the numerical dataset
        var numericalDataset = group.Dataset("numerical-dataset");
        var numericalData = numericalDataset.Read<double[]>();
        Console.WriteLine("Numerical Dataset: " + string.Join(", ", numericalData));

        // Read the string dataset
        var stringDataset = group.Dataset("string-dataset");
        var stringData = stringDataset.Read<string[]>();
        Console.WriteLine("String Dataset: " + string.Join(", ", stringData));

        // Read the numerical attribute
        var numericalAttribute = group.Attribute("numerical-attribute");
        var numericalAttributeData = numericalAttribute.Read<double[]>();
        Console.WriteLine("Numerical Attribute: " + string.Join(", ", numericalAttributeData));

        // Read the string attribute
        var stringAttribute = group.Attribute("string-attribute");
        var stringAttributeData = stringAttribute.Read<string[]>();
        Console.WriteLine("String Attribute: " + string.Join(", ", stringAttributeData));
    }
}