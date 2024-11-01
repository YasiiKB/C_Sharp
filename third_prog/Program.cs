namespace third_prog
{
    /*
    Base class (parent)
    - Any mutual function with parent and child will be overwritten by the func in parent
    unless vitrual keyword is used: public virtual void func()
    - Keyword "abstract" => this class canNOT be accessed directly, only from a derived class that inherits from it. (ABSTRACTION for SECUTIRY)
     */
    abstract class Person 
    {
        public string? Name  // property
            { get; set; }
        public string[] Pronouns  //? makes the property null-able
        { get; set; }
        public int Age 
            { get; set; }
        public bool Licence
            { get; set; }
    }

    /*
     * Derived class (child) - can only inheret (:) from one parent class, but from many interfaces
     * - Any mutual function with parent and child will be overwritten by the func in parent
     * unless override keyword is used: public override void func()
     */
    class Student : Person  
    {
         public string? Student_ID //property
            { get; set; }
        public void Study() //method
            {
            string l1 = $" and {Pronouns[1].ToLower()} Student ID is {Student_ID}.";
            Console.WriteLine(l1);
            //Console.WriteLine($" and {Pronouns[1].ToLower()} Student ID is {Student_ID}.");
        }
    }
    /*
     Interface is like an abstract class. But one class can inheret from multiple interfaces.
     - Interface methods do not have a body - the body is provided by the "implement" class
     - Interfaces can contain properties and methods, but not fields/variables
     - Interface members are by default abstract and public (no need to specify this)
     */
    interface ISchool
    {
        //string? SchoolName; -- ERROR: interface cannot contain fields
        string? SchoolName // property
            { get; set; }
        void SchoolDetails(); // no body for this method 
    }

    interface ILocation
    {
        string? CityName
            { get; set; }
        string? CountryName 
            { get; set; }
        void LocDetails();

    }

    class University : Person, ISchool, ILocation // this class inherets from 1 parent class (Person) and 2 interfaces
    {   
        string[] Pronouns = ["He", "His", "They", "Them"]; //need to initialize here to avoid NullReferenceException error
        public string? SchoolName
        { get; set; }
        public string? CityName
        { get; set; }
        public string? CountryName
        { get; set; }
        public void SchoolDetails() // body for the method in Interface
        {
            string l2 = $"{Pronouns[0]} goes to {SchoolName},";
            Console.Write(l2);
            //Console.Write($"{Pronouns[0]} goes to {SchoolName},");
        }
        public void LocDetails()
        {
            string l3 = $" which is a university in {CityName} in {CountryName}.";
            Console.WriteLine(l3);
            //Console.WriteLine($" which is a university in {CityName} in {CountryName}.");
        }
    }

    // Main
    class Program
    {
        // Use enums when you have values that you know aren't going to change,
        // like month days, days, colors, deck of cards, etc.
        enum Level
        {
            bachelor, master, PhD
        }
        static void Main() // no args are required
        {
  
            Student p1 = new Student();
            p1.Name = "Liam Smith";
            p1.Age = 19;
            p1.Licence = false;
            p1.Student_ID = "202425";
            p1.Pronouns = ["He", "His", "They", "Them"];
            //Console.WriteLine(p1.Pronouns.Length);

            Level StudyLevel = Level.bachelor;

            University u1 = new University();
            u1.SchoolName = "TU/e";
            u1.CityName = "Eindhoven";
            u1.CountryName = "the Netherlands";

            string l4 = $"{p1.Name} is {p1.Age} years old. {p1.Pronouns[0]} is a {StudyLevel} student";
            Console.Write(l4);
            //Console.Write($"{p1.Name} is {p1.Age} years old. {p1.Pronouns[0]} is a {StudyLevel} student");

            p1.Study();
            u1.SchoolDetails();
            u1.LocDetails();
            
            if (p1.Age < 18 || p1.Licence == false)
            {
                string l5 = $"{p1.Pronouns[0]} can't drive!";
                Console.WriteLine(l5);
                //Console.WriteLine($"{p1.Pronouns[0]} can't drive!");
            }
            else
            {
                string l6 = $"{p1.Pronouns[0]} can drive!";
                Console.WriteLine(l6);
                //Console.WriteLine($"{p1.Pronouns[0]} can drive!");
            }
        }
    }

}

