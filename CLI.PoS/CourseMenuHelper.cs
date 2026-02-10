using CLI.PoS.Model; // Make sure you can see the Course class
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI.PoS
{
	internal class CourseMenuHelper
	{
		private ModuleMenuHelper moduleMenuHelper = new ModuleMenuHelper();
		private AssignmementMenuHelper assignmentMenuHelper = new AssignmentMenuHelper();

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
					Console.WriteLine("7. Manage Assignments");
					Console.WriteLine("8. Manage Modules");
					Console.WriteLine("9. Unenroll a Student");
					Console.WriteLine("10. Update Course Description");
				}

				Console.WriteLine("0. Back");

				var choice = Console.ReadLine();
				if (int.TryParse(choice, out int choiceInt))
				{
					switch (choiceInt)
					{
						case 1:
							//ViewModules();
							break;
						case 2:
							//ViewAssignments();
							break;
						case 3:
							//ViewStudents();
							break;
						case 4:
							//CourseSchedule();
							break;
						case 5:
							SubmitAssignment();
							break;
						case 6:
							Console.WriteLine("Unenroll from course (not implemented yet)");
							UnenrollStudent();
							break;
						case 7:
							Console.WriteLine("Assignment Menu: (not implemented yet)");
							assignmentMenuHelper.PrintAssignmentMenu(course);
							break;
						case 8:
							moduleMenuHelper.PrintModuleMenu(course);
							break;
						case 9:
							UnenrollStudent();
							break;
						case 10:
							UpdateCourseDescription(courses);
							break;
						case 0:
							running = false;
							return;
						default:
							Console.WriteLine("Unknown choice.");
							break;
					}
				}
			}
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

			submissions.Add(submission); // just for now, broken/doesnt exist

			Console.WriteLine("Assignment successfully turned in.");
		}

		private void UnenrollStudent()
		{
			Console.WriteLine("Unenroll logic coming in a future sprint.");
		}

		private void UpdateCourseDescription(List<Course> courses)
		{
			if (courses.Count == 0)
			{
				Console.WriteLine("No courses available.");
				return;
			}

			Console.WriteLine("Enter the Id of the course to update:");
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

			Console.WriteLine($"Current description: {course.Description}");
			Console.Write("New description: ");
			var newDesc = Console.ReadLine();

			// Stub: just update the description
			course.Description = newDesc;
			Console.WriteLine("Course description updated.");
		}

		private void AddAssignmentGroup(Course course)
		{
			Console.Write("Group name: ");
			var name = Console.ReadLine();

			var group = new AssignmentGroup
			{
				Id = course.AssignmentGroups.Count + 1,
				Name = name,
				Weight = 0
			};

			course.AssignmentGroups.Add(group);

			Console.WriteLine("Group added.");
		}

		private void AddAssignmentToGroup(Course course)
		{
			Console.Write("Group Id: ");
			int gid = int.Parse(Console.ReadLine());

			var group = course.AssignmentGroups
							  .FirstOrDefault(g => g.Id == gid);

			if (group == null)
			{
				Console.WriteLine("Group not found.");
				return;
			}

			Console.Write("Assignment Id: ");
			int aid = int.Parse(Console.ReadLine());

			var assignment = course.Assignments
								   .FirstOrDefault(a => a.Id == aid);

			if (assignment == null)
			{
				Console.WriteLine("Assignment not found.");
				return;
			}

			group.Assignments.Add(assignment);

			Console.WriteLine("Assignment added to group.");
		}

		private void SetGroupWeight(Course course)
		{
			Console.Write("Group Id: ");
			int id = int.Parse(Console.ReadLine());

			var group = course.AssignmentGroups
							  .FirstOrDefault(g => g.Id == id);

			if (group == null)
			{
				Console.WriteLine("Group not found.");
				return;
			}

			Console.Write("Enter weight (0–1): ");
			double weight = double.Parse(Console.ReadLine());

			group.Weight = weight;

			Console.WriteLine("Weight updated.");
		}

		public double CalculateFinalGrade(Student student, Course course)
		{
			double total = 0;

			foreach (var group in course.AssignmentGroups)
			{
				double groupTotal = 0;
				int count = 0;

				foreach (var assignment in group.Assignments)
				{
					var submission = assignment.Submissions
						.FirstOrDefault(s => s.StudentId == student.Id);

					if (submission != null && submission.Grade.HasValue)
					{
						groupTotal += submission.Grade.Value;
						count++;
					}
				}

				if (count > 0)
				{
					double groupAvg = groupTotal / count;
					total += groupAvg * group.Weight;
				}
			}

			return total;
		}


	}
}