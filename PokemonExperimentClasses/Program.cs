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
            // create a list that will keep track of all the pokemon caught in a session
            List<string> collection = new List<string>();

            // loop this process for as long as the user wants (or they run out of pokeballs)
            do
            {
                // keep the UI nice and clean for each new encounter
                Console.Clear();
                Console.WriteLine("Welcome to the safari zone!");
                
                // generate a random number
                Random r = new Random();

                // roll to see if the pokemon will flee after the first action
                int flee = r.Next(1, 100);

                // generate a new pokemon to encounter
                Mon encounter = new Mon(r);
                encounter.GenerateEncounter();

                // run DuringEncounter method. If it returns true, add the current pokemon to our list of caught pokemon
                if (DuringEncounter(encounter, flee))
                {
                    Console.WriteLine("\nGotcha! {0} was caught!", encounter.Name);
                    collection.Add(encounter.Name);
                }

                // break out of the loop if the user runs out of pokeballs
                if (ballsLeft <= 0)
                {
                    Console.WriteLine("\nYou are out of pokeballs!!");
                    break;
                }

                // prompt user to continue or not
                Console.Write("\nLook for more pokemon? (y/n)");
            }
            // validate user input then return true or false
            while (PlayAgain());


            // print all pokemon in our list to the console
            Console.WriteLine("\nThank you for playing! Here is all the pokemon you caught:");
            foreach (string mon in collection)
            {
                Console.WriteLine(mon);
            }

            // finish
            Console.WriteLine("\nPress any key to close.");
            Console.ReadKey();


        }
        static bool DuringEncounter(Mon enc, int flee)
        {
            // initialize a bool to track whether or not we've caught the current pokemon
            bool caught = false;

            // inform the user how many pokeballs are remaining and what options they have
            Console.WriteLine("You have {0} pokeballs left.", ballsLeft);
            Console.WriteLine("1: Throw Ball");
            Console.WriteLine("2: Feed Berry");
            Console.WriteLine("3: Run");
            Console.WriteLine("");
            Console.Write("(enter a number):");

            // Validate input and store it as an int
            int choice = ValidateInt();
            
            // choose action based on user input
            if (choice == 1)
            {
                // decrement pokeballs by 1
                ballsLeft--;

                // use ThrowBall method to determine if the pokemon was caught
                caught = enc.ThrowBall();
            }
            if (choice == 2)
            {
                // use FeedBerry method to increase the pokemon's catch rate
                enc.FeedBerry();
            }
            if (choice == 3)
            {
                // return false, leaving the current encounter
                enc.Run();
                return false;
            }

            if (caught)
            {
                // if caught was set to true by ThrowBall(), return true
                return true;
            }
            else
            {

                if (flee <= enc.FleeRate || ballsLeft <= 0)
                {
                    // if our random int "flee" is less than the pokemon's flee rate or if user ran out of pokeballs, end the encounter
                    Console.WriteLine("\nOh no! {0} ran away. :(", enc.Name);
                    return false;
                }

                // allow user to keep choosing actions if the pokemon still hasn't fled or been caught
                else
                {
                    // give pokemon another opportunity to flee by rerolling "flee"
                    Random s = new Random();
                    flee = s.Next(1, 100);

                    // start back at the beginning of the method
                    return DuringEncounter(enc, flee);
                }
            }
        }

        static int ValidateInt()
        {
            try
            {
                // attempt to parse user input as an int
                int userInt = int.Parse(Console.ReadLine());

                // check if userInt is 1 2 or 3
                if (userInt == 1 || userInt == 2 || userInt == 3)
                {
                    return userInt;
                }
                else
                {
                    // try again
                    Console.Write("Invalid. Please enter 1 2 or 3: ");
                    return ValidateInt();
                }
            }
            catch
            {
                // try again
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
