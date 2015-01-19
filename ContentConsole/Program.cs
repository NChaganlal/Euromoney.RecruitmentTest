using System;
using System.Collections.Generic;
using System.Linq;
using Content.Data;
using Content.Manipulation;

namespace ContentConsole
{
    public static class Program
    {
        private static readonly INegativeWordRepository NegativeWordRepository = new NegativeWordRepository();
        private static readonly INegativeWordScanner NegativeWordScanner = new NegativeWordScanner(NegativeWordRepository);

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
                Console.WriteLine("2 - admin");
                Console.WriteLine("3 - reader");
                Console.WriteLine("4 - curator");
                Console.WriteLine("Type 'exit' to quit");
                Console.WriteLine("What is your role?");
                var role = Console.ReadLine();

                switch (role)
                {
                    case "1":
                        UserScreen();
                        break;
                    case "2":
                        AdminScreen();
                        break;
                    case "3":
                        ReaderScreen();
                        break;
                    case "4":
                        CuratorScreen();
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

        private static void AdminScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome Admin!");
            var negativeWordsStored = NegativeWordRepository.GetNegativeWords();
            Console.WriteLine("These are the words stored:");
            negativeWordsStored = negativeWordsStored ?? new List<string>();
            negativeWordsStored.ForEach(word => Console.WriteLine(word));
            Console.WriteLine("1 - Change bad words stored");
            Console.WriteLine("2 - Go back to main Menu");
            Console.WriteLine("What do you want to do?");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter new bad words separated by spaces:");
                    var newBadWords = Console.ReadLine() ?? string.Empty;
                    NegativeWordRepository.SaveNegativeWords(newBadWords.Split(' ').ToList());
                    Console.WriteLine("New words have been saved!");
                    break;
                case "2":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("The options at this stage are: 1,2");
                    break;
            }
        }

        private static void ReaderScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome Reader!");
            Console.WriteLine("Text to scan:");
            var content = Console.ReadLine();
            Console.WriteLine("Scanned the text: ");
            Console.WriteLine(NegativeWordScanner.FilterNegativeWordsFromContent(content));
            Console.WriteLine("Total Number of negative words: " + NegativeWordScanner.CountNegativeWords(content));
            Console.ReadKey();
        }

        private static void CuratorScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome Curator!");
            Console.WriteLine("Do you want to disable negative word filtering? (y/n)");
            var option = Console.ReadLine();
            Console.WriteLine("Text to scan:");
            var content = Console.ReadLine();
            Console.WriteLine("Scanned the text: ");

            switch (option)
            {
                case "n":
                    Console.WriteLine(NegativeWordScanner.FilterNegativeWordsFromContent(content));
                    Console.WriteLine("Total Number of negative words: " + NegativeWordScanner.CountNegativeWords(content));
                    Console.ReadKey();
                    break;
                case "y":
                    Console.WriteLine(content);
                    Console.WriteLine("Total Number of negative words: " + NegativeWordScanner.CountNegativeWords(content));
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("The options at this stage are: 'y' or 'n'");
                    break;
            }
        }
    }

}
