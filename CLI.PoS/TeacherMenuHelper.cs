using CLI.PoS.Model; // Make sure you can see the Course class
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI.PoS
{
	internal class TeacherMenuHelper
	{
		private List<Course> courses = new List<Course>();
		private CourseMenuHelper courseMenuHelper = new CourseMenuHelper();

		public void PrintTeacherMenu()
		{
			bool running = true;

			while (running)
			{
				Console.WriteLine("\nTeacher Menu:");
				Console.WriteLine("1. Add new course");
				Console.WriteLine("2. Browse courses");
				Console.WriteLine("3. Select a student to proxy")
				Console.WriteLine("4. Delete a course");
				Console.WriteLine("5. Copy a course");
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
							BrowseCourses();
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

			Console.WriteLine("Semester (ex: Fall 2026):");
			var semester = Console.ReadLine();

			Console.Write("Enter section (ex: 001, A, B2): ");
			var section = Console.ReadLine();

			var course = new Course
			{
				Id = courses.Count + 1, // just for now
				Name = name,
				Code = code,
				Description = description,
				Semester = semester,
				Section = section
			};

			courses.Add(course);

			Console.WriteLine("Course added successfully.");
		}

		private void BrowseCourses()
		{
			if (courses.Count == 0)
			{
				Console.WriteLine("No courses available.");
				return;
			}

			while (true)
			{
				Console.WriteLine("\nCourse Browser");
				Console.WriteLine("1. View courses grouped by semester");
				Console.WriteLine("2. View all courses");
				Console.WriteLine("3. Filter by semester");
				Console.WriteLine("4. Select a course");
				Console.WriteLine("0. Back");

				Console.Write("Choice: ");
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						DisplayGroupedBySemester();
						break;

					case "2":
						DisplayAllCourses(courses);
						break;

					case "3":
						FilterBySemester();
						break;

					case "4":
						SelectCourseFromList(courses);
						break;

					case "0":
						return;

					default:
						Console.WriteLine("Invalid option.");
						break;
				}
			}
		}

		private void FilterBySemester()
		{
			Console.Write("Enter semester (ex: Fall 2025): ");
			var semester = Console.ReadLine();

			var filtered = courses
				.Where(c => c.Semester.Equals(semester, StringComparison.OrdinalIgnoreCase))
				.ToList();

			if (filtered.Count == 0)
			{
				Console.WriteLine("No courses found for that semester.");
				return;
			}

			DisplayAllCourses(filtered);
		}

		private void SelectCourseFromList(List<Course> list)
		{
			DisplayAllCourses(list);

			Console.Write("\nEnter the course Id to select: ");

			if (!int.TryParse(Console.ReadLine(), out int courseId))
			{
				Console.WriteLine("Invalid input.");
				return;
			}

			var selectedCourse = list.FirstOrDefault(c => c.Id == courseId);

			if (selectedCourse == null)
			{
				Console.WriteLine("Course not found.");
				return;
			}

			courseMenuHelper.PrintCourseMenu(selectedCourse, isTeacher: true);
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

		private void DisplayAllCourses(List<Course> list)
		{
			Console.WriteLine("\nAvailable Courses:");

			foreach (var course in list)
			{
				Console.WriteLine(
					$"{course.Id}: {course.Name} ({course.Code}) - {course.Semester}"
				);
			}
		}

		private void DisplayGroupedBySemester()
		{
			Console.WriteLine("\nCourses by Semester:");

			var grouped = courses
				.GroupBy(c => c.Semester)
				.OrderBy(g => g.Key);

			foreach (var group in grouped)
			{
				Console.WriteLine($"\n=== {group.Key} ===");

				foreach (var course in group)
				{
					Console.WriteLine(
						$"{course.Id}: {course.Name} ({course.Code})"
					);
				}
			}
		}


		private void CopyCourse()
		{
			Console.Write("Enter course Id to copy: ");
			int id = int.Parse(Console.ReadLine());

			var original = courses.FirstOrDefault(c => c.Id == id);

			if (original == null)
			{
				Console.WriteLine("Course not found.");
				return;
			}

			var newCourse = DeepCopyCourse(original);

			courses.Add(newCourse);

			Console.WriteLine($"Course copied as '{newCourse.Name}'.");
		}

		private Course DeepCopyCourse(Course original)
		{
			var newCourse = new Course
			{
				Id = courses.Count + 1,
				Name = original.Name + " (Copy)",
				Code = original.Code + "_COPY",
				Description = original.Description,
				Semester = original.Semester,
				Section = original.Section,

				// Empty roster
				Roster = new List<Student>(),

				Modules = new List<Module>(),
				Assignments = new List<Assignment>(),
				AssignmentGroups = new List<AssignmentGroup>()
			};

			// Copy Modules
			foreach (var module in original.Modules)
			{
				var newModule = new Module
				{
					Id = module.Id,
					Items = new List<ModuleItem>()
				};

				foreach (var item in module.Items)
				{
					newModule.Items.Add(item.Clone());
				}

				newCourse.Modules.Add(newModule);
			}

			// Copy Assignments
			foreach (var assignment in original.Assignments)
			{
				var newAssignment = new Assignment
				{
					Id = assignment.Id,
					Name = assignment.Name,
					Description = assignment.Description,
					AvailablePoints = assignment.AvailablePoints,
					DueDate = assignment.DueDate,

					// No submissions
					Submissions = new List<Submission>()
				};

				newCourse.Assignments.Add(newAssignment);
			}

			// Copy Assignment Groups
			foreach (var group in original.AssignmentGroups)
			{
				var newGroup = new AssignmentGroup
				{
					Id = group.Id,
					Name = group.Name,
					Weight = group.Weight,
					Assignments = new List<Assignment>()
				};

				foreach (var assignment in group.Assignments)
				{
					var copied = newCourse.Assignments
						.FirstOrDefault(a => a.Id == assignment.Id);

					if (copied != null)
						newGroup.Assignments.Add(copied);
				}

				newCourse.AssignmentGroups.Add(newGroup);
			}

			return newCourse;
		}


	}
}