// A file to read the datasets and attributes from the HDF5 file using PureHDF
// Install: dotnet add package PureHDF --version 2.1.1

using PureHDF;
using System;

class Program
{
    static void Main()
    {
        // Path to the HDF5 file
        string myPath = "C:\\Users\\stude\\Desktop\\Learning\\PureHDF\\Writing\\";
        string filename = Path.Combine(myPath, "anothertestFile.h5");

        // Open the HDF5 file in read-only mode
        var file = H5File.OpenRead(filename);

        // Access the group
        var group = file.Group("my-group");

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