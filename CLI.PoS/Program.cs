using CLI.PoS;
using CLI.PoS.Model;
using Library.PoS.Services;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = ItemServiceProxy.Current.Items;

            Console.WriteLine("Choose one of the following:");
            Console.WriteLine("1. Administrator");
            Console.WriteLine("2. User");

            var choice = Console.ReadLine();
            if(int.TryParse(choice, out int choiceInt))
            {
                switch (choiceInt)
                {
                    case 1:
                        Console.WriteLine("Admin Menu");

                        Console.WriteLine("Name:");
                        var name = Console.ReadLine();
                        Console.WriteLine("Description:");
                        var description = Console.ReadLine();

                        Console.WriteLine("Price:");
                        var price = Console.ReadLine();

                        var item = new Item { 
                        Name = name, Description = description, Price = decimal.Parse(price)
                        };

                        Console.WriteLine(item);
                        list.Add(item);

                        break;
                    case 2:
                        Console.WriteLine("User Menu");
                        break;
                    default:
                        Console.WriteLine("ERROR: Unknown User Type");
                        break;
                }

               
            }


            
        }
    
        static void PrintStudentMenu()
        {

        }
    }
}