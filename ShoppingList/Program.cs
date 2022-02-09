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
            List<string> cart = new List<string>();
            //intro message
            Console.WriteLine("Welcome to my shop!");
            Console.WriteLine();
            // displaying items and amount theyre worth
            while (runProgram)
            {
                Console.WriteLine(String.Format("{0,-15}{1,15}", "Item", "Price"));
                Console.WriteLine("==================================");
                //Clean up console after every item
                Console.Clear();
                foreach (KeyValuePair<string, double> item in menu.OrderBy(item => item.Value))
                {
                    Console.WriteLine(String.Format("{0,-15}{1,15}", item.Key, item.Value));
                }
                // accepting user input
                Console.WriteLine();
                while (runProgram)
                {
                    Console.Write("What item would you like to order? : ");
                    string menuChoice = Console.ReadLine().ToLower().Trim();

                    //checks if exists
                    if (menu.ContainsKey(menuChoice))
                    {
                        Console.WriteLine($"Adding {menuChoice} to the cart at {menu[menuChoice]}");
                        cart.Add(menuChoice);
                        //asks if continue
                        while (runProgram)
                        {
                            Console.WriteLine("Would you like to continue shopping? y/n");
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
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid input entered.");
                        break;
                    }

                }

                //display cart
                Console.WriteLine();
                Console.WriteLine("This is your order: ");
                double total = 0;
                //highest price
                string highestName = "lotto ticket";
                //lowest price
                string lowestName = "banana";

                foreach (string item in cart)
                {
                    Console.WriteLine(string.Format("{0.-15} {1,15}", item, menu[item]));
                    total += menu[item];
                    if (menu[item] >= menu[highestName])
                    {
                        highestName = item;
                    }
                    if (menu[item] <= menu[lowestName])
                    {
                        lowestName = item;
                    }
                }
                Console.WriteLine($"Average price per item in order was {Math.Round(total / cart.Count, 2)}");
                Console.WriteLine($"The highest priced item was {highestName}");
                Console.WriteLine($"The lowest price item was {lowestName}");

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



