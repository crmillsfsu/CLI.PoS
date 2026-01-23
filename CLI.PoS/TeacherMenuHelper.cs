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
				Console.WriteLine("3. Select a student to proxy")
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
						case 3:
							ProxyStudent();
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

		private void AddCourse()
		{
			Console.WriteLine("Course Name:");
			var name = Console.ReadLine();

			Console.WriteLine("Course Code:");
			var code = Console.ReadLine();

			Console.WriteLine("Course Description:");
			var description = Console.ReadLine();

			var course = new Course
			{
				Id = courses.Count + 1, // just for now
				Name = name,
				Code = code,
				Description = description
			};

			courses.Add(course);

			Console.WriteLine("Course added successfully.");
		}
	}
}