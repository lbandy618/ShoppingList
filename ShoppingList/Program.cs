using System;

namespace ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // menu dictionary
            Dictionary<string, double> menu = new Dictionary<string, double>()
            {
                ["banana"] = 0.59,
                ["apple"] = 0.69,
                ["gum"] = 0.89,
                ["arizona tea"] = 0.99,
                ["baja blast"] = 1.59,
                ["reeses"] = 2.59,
                ["red bull"] = 3.59,
                ["lotto ticket"] = 4.59,

            };
            bool runProgram = true;
            // shopping list
            List<string> order = new List<string>();
            //intro message
            Console.WriteLine("Welcome to my shop!");
            Console.WriteLine();
            // displaying items and amount theyre worth
            while (runProgram)
            {
                Console.WriteLine(String.Format("{0,-15}{1,15}", "Item", "Price"));
                Console.WriteLine("==================================");

                foreach (KeyValuePair<string, double> kvp in menu)
                {
                    Console.WriteLine(String.Format("{0,-15}{1,15}", kvp.Key, kvp.Value));
                }
                // accepting user input
                Console.WriteLine();
                while (runProgram)
                {
                    Console.Write("What item would you like to order?: ");
                    string menuChoice = Console.ReadLine().ToLower().Trim();
                    order.Add(menuChoice);

                    if (menu.ContainsKey(menuChoice))
                    {
                        Console.WriteLine($"Adding {menuChoice} to the cart at {menu[menuChoice]}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid input entered.");
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Would you like to continue y/n");
                    string loopCheck = Console.ReadLine();
                    if (loopCheck.ToLower().Trim() == "y")
                    {
                        runProgram = true;
                        break;
                    }
                    else if (loopCheck.ToLower().Trim() == "n")
                    {
                        runProgram = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid response");
                        Console.WriteLine();
                    }

                }
            }
        }
    }
}



