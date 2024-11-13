// Reading File Structure and data from a .H5 file 
// dotnet add package HDF5-CSharp --version 1.19.0
// From https://www.nuget.org/packages/HDF5-CSharp/

using HDF5CSharp;

namespace HDF5Read
{
    // ReadFlatFileStructure shows these (Only needed for using the data later on
    // No Schema is produced or needed
    class TestClassRead
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

    class Read
    {
        static void Main(string[] args)
        {
            // File Path
            string myPath = "C:\\Users\\stude\\Desktop\\Learning\\HD5Create\\";
            string fileName = myPath + "testFile.H5";

            // Open the HDF5 file for reading
            long fileId = Hdf5.OpenFile(fileName);

            // Read and display the file structure (optional)
            var tree = Hdf5.ReadFlatFileStructure(fileName);
            foreach (var item in tree)
            {
                Console.WriteLine(item);
            }

            // Create an object to hold data 
            TestClassRead readObject = new TestClassRead();

            // Read from file
            readObject = Hdf5.ReadObject(fileId, readObject, "testObject");

            // Close the file after reading
            Hdf5.CloseFile(fileId);

            // Output read object to verify
            Console.WriteLine($"TestInteger: {readObject.TestInteger}");
            Console.WriteLine($"TestDouble: {readObject.TestDouble}");
            Console.WriteLine($"TestBoolean: {readObject.TestBoolean}");
            Console.WriteLine($"TestString: {readObject.TestString}");
            Console.WriteLine("TestDoubles: " + string.Join(", ", readObject.TestDoubles));
            Console.WriteLine("TestStrings: " + string.Join(", ", readObject.TestStrings));
            Console.WriteLine("ComplexNumbers: ");
            for (int i = 0; i < readObject.TestReals.Length; i++)
            {
                Console.WriteLine($"{readObject.TestReals[i]} + {readObject.TestImaginaries[i]}i");
            }
        }
    }
}
