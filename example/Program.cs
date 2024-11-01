using Google.Protobuf;
using Google.Protobuf.Compiler;

class Program
{
    static void Main(string[] args)
    {
        // Create employee instances
        Employee hussein = new Employee
        {
            Id = 1001,
            Name = "Hussein",
            Salary = 1001
        };

        Employee ahmed = new Employee
        {
            Id = 1002,
            Name = "Ahmed",
            Salary = 9000
        };

        Employee rick = new Employee
        {
            Id = 1003,
            Name = "Rick",
            Salary = 5000
        };

        // Create a Employees object and add employees to it
        var employees = new Employees();
        employees.Employees_.Add(hussein);
        employees.Employees_.Add(ahmed);
        employees.Employees_.Add(rick);

        // Serialize to binary
        using (var output = File.Create("C:\\Users\\stude\\Desktop\\Learning\\example\\employees.dat"))
        {
            employees.WriteTo(output);
        }
        Console.WriteLine("File Saved!");

        // Deserialize from binary
        using (var input = File.OpenRead("C:\\Users\\stude\\Desktop\\Learning\\example\\employees.dat"))
        {
            rick = Employee.Parser.ParseFrom(input);
        }
        Console.WriteLine(rick.Id); // prints 0?
    }
}
