using CLI.PoS.Model; // Make sure you can see the Course class
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI.PoS
{
	internal class TeacherMenuHelper
	{
		private List<Course> courses = new List<Course>();

		public void PrintTeacherMenu()
		{
			bool running = true;

			while (running)
			{
				Console.WriteLine("\nTeacher Menu:");
				Console.WriteLine("1. Add new course");
				Console.WriteLine("2. Select existing course");
				Console.WriteLine("0. Exit to main menu");

				var choice = Console.ReadLine();
				if (int.TryParse(choice, out int choiceInt))
				{
					switch (choiceInt)
					{
						case 1:
							AddCourse();
							break;
						case 2:
							SelectCourse();
							break;
						case 0:
							running = false;
							break;
						default:
							Console.WriteLine("Unknown choice.");
							break;
					}
				}
			}
		}

		AddCourse()
		{
			Console.Write("Enter course name: ");
			var courseName = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(courseName))
			{
				var newCourse = new Course { Name = courseName };
				courses.Add(newCourse);
				Console.WriteLine($"Course '{courseName}' added.");
			}
			else
			{
				Console.WriteLine("Course name cannot be empty.");
			}
		}
	}
}