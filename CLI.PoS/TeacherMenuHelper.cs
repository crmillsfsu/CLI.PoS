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
				Console.WriteLine("4. Delete a course");
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
							//SelectCourse();
							break;
						case 3:
							//ProxyStudent();
							break;
						case 4:
							DeleteCourse(courses);
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

		private void DeleteCourse(List<Course> courses)
		{
			if (courses.Count == 0)
			{
				Console.WriteLine("No courses available to delete.");
				return;
			}

			Console.WriteLine("Enter the Id of the course to delete:");
			int id;
			if (!int.TryParse(Console.ReadLine(), out id))
			{
				Console.WriteLine("Invalid input.");
				return;
			}

			var course = courses.FirstOrDefault(c => c.Id == id);
			if (course == null)
			{
				Console.WriteLine("Course not found.");
				return;
			}

			// Stub: remove the course from the list
			courses.Remove(course);

			// Note for later: enrolled students remain intact
			Console.WriteLine($"Course '{course.Name}' deleted (students not affected).");
		}
	}
}