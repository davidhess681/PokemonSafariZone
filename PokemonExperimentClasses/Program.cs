using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonExperimentClasses
{
    class Program
    {
        static int ballsLeft = 30;

        static void Main(string[] args)
        {
            
            List<string> collection = new List<string>();
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the safari zone!");
                
                Random r = new Random();
                int flee = r.Next(1, 100);
                Mon encounter = new Mon(r);
                encounter.GenerateEncounter();
                if (DuringEncounter(encounter, flee))
                {
                    Console.WriteLine("\nGotcha! {0} was caught!", encounter.Name);
                    collection.Add(encounter.Name);
                }
                if (ballsLeft <= 0)
                {
                    Console.WriteLine("\nYou are out of pokeballs!!");
                    break;
                }
                Console.Write("\nLook for more pokemon? (y/n)");
            }
            while (PlayAgain());

            Console.WriteLine("\nThank you for playing! Here is all the pokemon you caught:");
            foreach (string mon in collection)
            {
                Console.WriteLine(mon);
            }
            Console.WriteLine("\nPress any key to close.");
            Console.ReadKey();


        }
        static bool DuringEncounter(Mon enc, int flee)
        {
            bool caught = false;

            Console.WriteLine("You have {0} pokeballs left.", ballsLeft);

            int choice = UserOptions();
            
            if (choice == 1)
            {
                ballsLeft--;
                caught = enc.ThrowBall();
            }
            if (choice == 2)
            {
                enc.FeedBerry();
            }
            if (choice == 3)
            {
                enc.Run();
                return false;
            }

            if (caught)
            {
                return true;
            }
            else
            {

                if (flee <= enc.FleeRate || ballsLeft <= 0)
                {
                    Console.WriteLine("\nOh no! {0} ran away. :(", enc.Name);
                    return false;
                }
                else
                {
                    Random s = new Random();
                    flee = s.Next(1, 100);
                    return DuringEncounter(enc, flee);
                }
            }
        }

        static int UserOptions()
        {
            Console.WriteLine("1: Throw Ball");
            Console.WriteLine("2: Feed Berry");
            Console.WriteLine("3: Run");
            Console.WriteLine("");
            Console.Write("(enter a number):");

            return ValidateInt();
        }

        static int ValidateInt()
        {
            try
            {
                int userInt = int.Parse(Console.ReadLine());
                return userInt;
            }
            catch (FormatException)
            {
                Console.Write("Invalid. Please enter 1 2 or 3: ");
                return ValidateInt();
            }
        }

        static bool PlayAgain()
        {
            // repeat the program if user types "y", close if "n"
            switch (Console.ReadLine())
            {
                case "y":
                    {
                        return true;
                    }
                case "n":
                    {
                        return false;
                    }
                default:
                    {
                        Console.Write("Invalid. Try again: ");
                        return PlayAgain();
                    }
            }
        }

        
    }

    
}
