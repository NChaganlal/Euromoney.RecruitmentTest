using System;
using Content.Manipulation;

namespace ContentConsole
{
    public static class Program
    {
        private static readonly INegativeWordScanner NegativeWordScanner = new NegativeWordScanner();

        public static void Main(string[] args)
        {
            MainMenu();   
        }

        private static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Roles available:");
                Console.WriteLine("1 - user");
                Console.WriteLine("Type 'exit' to quit");
                Console.WriteLine("What is your role?");
                var role = Console.ReadLine();

                switch (role)
                {
                    case "1":
                        UserScreen();
                        break;
                    case "exit":
                        Console.WriteLine("You typed exit! Goodbye!");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("The options at this stage are: 1 and exit");
                        break;
                }
            }
        }

        private static void UserScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome User!");
            Console.WriteLine("Text to scan:");
            var content = Console.ReadLine();
            Console.WriteLine("Scanned the text: ");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of negative words: " + NegativeWordScanner.CountNegativeWords(content));
            Console.ReadKey();
        }
    }

}
