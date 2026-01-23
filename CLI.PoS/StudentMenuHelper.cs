using System;
using System.Collections.Generic;
using System.Text;

namespace CLI.PoS
{
    internal class StudentMenuHelper
    {
        public void PrintStudentMenu()
        {
			var studentMenuHelper = new StudentMenuHelper();
			bool running = true;

			while (running)
			{
				Console.WriteLine("\nStudent Menu:");
				Console.WriteLine("1. See Course Menu")
				Console.WriteLine("0. Exit to main menu");

				var choice = Console.ReadLine();
				if (int.TryParse(choice, out int choiceInt))
				{
					switch (choiceInt)
					{
						case 1:
							PrintCourseMenu();
							break;
						case 0:
							studentMenuHelper.PrintStudentMenu
							running = false;
							break;
						default:
							Console.WriteLine("Unknown choice.");
							break;
					}
				}
			}
		}
    }
}