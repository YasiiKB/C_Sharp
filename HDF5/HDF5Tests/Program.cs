// Example from https://www.nuget.org/packages/HDF5-CSharp/
// Making a sample HDF5 file and saving it 

using HDF5CSharp;

namespace TestClassWithArray
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
        public double[] TestImaginaries{ get; set; }

        class Program
        {
            static void Main(string[] args)
            {
                // Create an instance of TestClasss
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
                string myPath = "C:\\Users\\stude\\Desktop\\Learning\\HDF5Tests\\";
                long fileId = Hdf5.CreateFile(myPath + "testFile_complex.H5");

                // Write the object to the file
                Hdf5.WriteObject(fileId, testClass, "testObject");

                // Close the file
                Hdf5.CloseFile(fileId);

                Console.WriteLine("File Created!");
            }
        }
    }
}
