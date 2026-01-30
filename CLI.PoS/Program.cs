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
            var choice = string.Empty;
            do
            {
                Console.WriteLine("Choose one of the following:");
                Console.WriteLine("1. Administrator");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Quit");

                choice = Console.ReadLine();
                if (int.TryParse(choice, out int choiceInt))
                {
                    var subChoice = string.Empty;
                    do
                    {
                        switch (choiceInt)
                        {
                            case 1:
                                Console.WriteLine("Admin Menu");
                                Console.WriteLine("C. Create New Menu Item");
                                Console.WriteLine("U. Edit Menu Item");
                                Console.WriteLine("Q. Quit");

                                subChoice = Console.ReadLine();
                                if (subChoice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    Console.WriteLine("Name:");
                                    var name = Console.ReadLine();
                                    Console.WriteLine("Description:");
                                    var description = Console.ReadLine();

                                    Console.WriteLine("Price:");
                                    var price = Console.ReadLine();

                                    var item = new Item
                                    {
                                        Name = name,
                                        Description = description,
                                        Price = decimal.Parse(price)
                                    };
                                    ItemServiceProxy.Current.AddOrUpdate(item);

                                    Console.WriteLine(item);
                                }
                                else if (subChoice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    //display the items in their current state
                                    list.ForEach(Console.WriteLine);

                                    //let a user choose which one to update
                                    var editChoice = int.Parse(Console.ReadLine() ?? "0");
                                    var itemToEdit = list.FirstOrDefault(i => i.Id == editChoice);

                                    if (itemToEdit != null)
                                    {
                                        //make the update
                                        Console.WriteLine("New Name:");
                                        var newName = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newName))
                                        {
                                            itemToEdit.Name = newName;
                                        }
                                        Console.WriteLine("New Price:");
                                        var newPrice = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(newPrice))
                                        {
                                            itemToEdit.Price = decimal.Parse(newPrice);
                                        }


                                        ItemServiceProxy.Current.AddOrUpdate(itemToEdit);
                                    }
                                }
                                break;
                            case 2:
                                Console.WriteLine("User Menu");
                                break;
                            case 3:
                                break;
                            default:
                                Console.WriteLine("ERROR: Unknown User Type");
                                break;
                        }
                    } while (!subChoice.Equals("Q", StringComparison.InvariantCultureIgnoreCase)
                            && choiceInt != 3
                        );
                }


            } while (!choice.Equals("3", StringComparison.OrdinalIgnoreCase));
        }
    
        static void PrintStudentMenu()
        {

        }
    }
}