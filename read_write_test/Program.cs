using System.IO;

class Program
{
    static void Main() // no args are required
    {
        try
        {
            Console.Write("Enter the number of hours worked:");
            double workedHours = Convert.ToDouble(Console.ReadLine());

            // catch negetive input
            if (workedHours < 0)
            {
                Console.WriteLine("Number of hours can't be negative!");
            }

            Console.Write("Enter your hourly pay rate:");
            double hourlyPay = Convert.ToDouble(Console.ReadLine());

            // catch negetive input
            if (hourlyPay < 0)
            {
                Console.WriteLine("Hourly pay rate can't be negative!");
                return;
            }

            double Salary = workedHours * hourlyPay;

            string writeText = $"Your salary is {Salary} for this month.";  // Create a text string
            File.WriteAllText("salary.txt", writeText);  // Create a file and write the content of writeText to it

            string readText = File.ReadAllText("salary.txt");  // Read the contents of the file
            Console.WriteLine(readText);  // Output the content
        }

        // Invalid input
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid number.");
            return;
        }
        // Other errors
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
            return;
        }
    }
}
