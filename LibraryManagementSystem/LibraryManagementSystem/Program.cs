namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("    Library Management System    ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Book Management");
                Console.WriteLine("2. Category Management");
                Console.WriteLine("3. Member Management");
                Console.WriteLine("4. Borrowing Management");
                Console.WriteLine("5. Reports");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect an option (1-6): ");

                ConsoleKeyInfo choice = Console.ReadKey();
                              
                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("\n[Book Management selected... Press any key to return]");
                        Console.ReadKey();
                        // TODO: Call your Book Management service/menu here
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("\n[Category Management selected... Press any key to return]");
                        Console.ReadKey();
                        // TODO: Call Category Management
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("\n[Member Management selected... Press any key to return]");
                        Console.ReadKey();
                        // TODO: Call Member Management
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine("\n[Borrowing Management selected... Press any key to return]");
                        Console.ReadKey();
                        // TODO: Call Borrowing Management
                        break;

                    case ConsoleKey.D5:
                        Console.WriteLine("\n[Reports selected... Press any key to return]");
                        Console.ReadKey();
                        // TODO: Call Reports
                        break;

                    case ConsoleKey.D6:
                        exit = true;
                        Console.WriteLine("\nExiting application. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid option! Please enter a number between 1 and 6. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }

            }
    }
}
