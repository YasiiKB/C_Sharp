using System;

namespace Cars
{
    class Car
    {
        // Class members
        public string color;        // field
        public string model;        // "public": this field/method is accessible for other classes too e.g. Program
        public int maxSpeed;       // field

        // Method
        public void FullThrottle()
        {
            Console.WriteLine($"The {color} {year} {model} is going as fast as it can!");
        }
    }

    class Program // Adding a Program class to contain the Main method
    {
        static void Main(string[] args)
        {
            Car Ford = new Car();
            Ford.model = "Mustang";
            Ford.color = "red";
            Ford.year = 1969;
            Ford.maxSpeed = 50;

            Car Opel = new Car();
            Opel.model = "Astra";
            Opel.color = "white";
            Opel.year = 2005;
            Opel.maxSpeed = 20;

            // Conditional check
            if (Ford.maxSpeed >= 200)
            {
                Ford.FullThrottle(); // Call method on the Ford instance
            }
            if (Opel.maxSpeed >= 200)
            {
                Opel.FullThrottle(); // Call method on the Opel instance
            }
            if (Ford.maxSpeed < 200 && Opel.maxSpeed < 200)
            {
                Console.WriteLine("No Throttling Cars!");
            }
        }
    }
}