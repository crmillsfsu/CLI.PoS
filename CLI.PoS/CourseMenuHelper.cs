using CLI.PoS.Model; // Make sure you can see the Course class
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI.PoS
{
	internal class CourseMenuHelper
	{
		private List<Assignment> assignments = new List<Assignment>(); // link somehow if not already
		private <List<Submission> submissions = new List<Submission>();

		public void PrintCourseMenu(Course course, bool isTeacher)
		{
			bool running = true;

			while (running)
			{
				Console.WriteLine($"\n{course.Name} ({course.Code})");
				Console.WriteLine("1. See modules");
				Console.WriteLine("2. See assignments");
				Console.WriteLine("3. See students");
				Console.WriteLine("4. See course schedule");

				if (!isTeacher)
				{
					Console.WriteLine("5. Submit assignment");
					Console.WriteLine("6. Unenroll from course");
				}

				if (isTeacher)
				{
					Console.WriteLine("7. Add assignment");
					Console.WriteLine("8. Unenroll a student");
				}

				Console.WriteLine("0. Back");

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
						case 5:
							SubmitAssignment();
						case 6:
							Console.WriteLine("Unenroll from course (not implemented yet)");
							UnenrollStudent();
							break;
						case 7:
							Console.WriteLine("Add Assignment: (not implemented yet)");
							AddAssignment();
							break;
						case 0:
							running = false;
							PrintStudentMenu();
						default:
							Console.WriteLine("Unknown choice.");
							break;
					}
				}
			}
		}

		private void UnenrollStudent()
		{
			Console.WriteLine("Unenroll logic coming in a future sprint.");
		}

		private void AddAssignment()
		{
			Console.WriteLine("Assignment Name:");
			var name = Console.ReadLine();

			Console.WriteLine("Assignment Description:");
			var description = Console.ReadLine();

			var assignment = new Assignment
			{
				Id = assignments.Count + 1, // just for now
				Name = name,
				Description = description
			};

			assignments.Add(assignment);

			Console.WriteLine("Assignment added successfully.");
		}

		private void SubmitAssignment()
		{
			Console.WriteLine("Assignment Work:");
			var content = Console.ReadLine();

			var submission = new Submission
			{
				Id = assignments.Count + 1, // just for now
				Content = content
			};

			submissions.Add(submission);

			Console.WriteLine("Assignment successfully turned in.");
		}

	}
}