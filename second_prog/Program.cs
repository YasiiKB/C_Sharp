using System;
using System.Drawing;

namespace second_prog //same as file name (otw WARNING)
{
    // Step 1: Define a custom attribute
    [AttributeUsage(AttributeTargets.Method)] // This attribute can only be applied to methods (targets)
    // Create a new attribute called ThrottleDecorator
    public class ThrottleDecoratorAttribute : Attribute  // This class inherites from the Attribute base class (unless you specify not to: [AttributeUsage(AttributeTargets.Method, Inherited = false)])
    {
        public void Before(string model)  // a method in the custom attribute
        {
            //Console.WriteLine("Preparing to accelerate...");
            Console.WriteLine($"The {model} is preparing to accelerate...!");

        }
    }

    // Step 2: Define the Car class with a decorated method
    public class Car
    {
        // Class Members
        public string color;        // field
        public string model;        // field
        public int year;           // field
        public int maxSpeed;       // field

        //Create Constructor 
        public Car (string modelName, string carColor, int carYear, int carMaxSpeed)
        {
            model = modelName;
            color = carColor;
            year = carYear;
            maxSpeed = carMaxSpeed;
        }

        // Define Decorated method (if you don't apply it, it won't work!)
        [ThrottleDecoratorAttribute] // Apply the custom attribute to this method (Can also only use: ThrottleDecorator) 
        public void FullThrottle()
        {
            Console.WriteLine($"The {year} {color} {model} is going as fast as it can!");
        }
    }

    // Step 3: Use the attribute in the main program
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an instance of the Car class (WITHOUT CONSTRUCTOR)
            //Car Ford = new Car()
            //{
            //    color = "red",
            //    model = "Mustang",
            //    year = 1969,
            //    maxSpeed = 200
            //};

            // Create an instance of the Car class (WITH CONSTRUCTOR)
            Car Ford = new Car("Mustang", "red", 1969, 200);
            Car Opel = new Car("Astra", "white", 2001, 150);

            // Get metadata (param., return type, associated attr., etc.) for the FullThrottle method
            var FordmethodInfo = Ford.GetType().GetMethod("FullThrottle");
            var OpelmethodInfo = Opel.GetType().GetMethod("FullThrottle");


            // Check for the ThrottleDecorator attribute on FullThrottle
            /*
                * The result of GetCustomAttribute is cast to ThrottleDecoratorAttribute.
                * If the attribute is found, attribute will hold a reference to it; if not, attribute will be null.
                */
            var FordAttribute = (ThrottleDecoratorAttribute)Attribute.GetCustomAttribute(FordmethodInfo, typeof(ThrottleDecoratorAttribute));
            var OpelAttribute = (ThrottleDecoratorAttribute)Attribute.GetCustomAttribute(OpelmethodInfo, typeof(ThrottleDecoratorAttribute));

            // If the attribute exists (?. Null-conditional Operator), call the Before method
            FordAttribute?.Before(Ford.model);
            OpelAttribute?.Before(Opel.model); 

            // Now call the actual method if condition is met
            if (Ford.maxSpeed >= 200)
            {
                Ford.FullThrottle(); // Call method on the Ford instance
            }
            if (Opel.maxSpeed >= 200)
            {
                Opel.FullThrottle(); // Call method of the Opel instance
            }
            if (Ford.maxSpeed < 200 && Opel.maxSpeed < 200)
            {
                Console.WriteLine("No Throttling Cars!");
            }
        }
    }
}
