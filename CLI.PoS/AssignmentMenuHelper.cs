using CLI.PoS.Model;
using System;
using System.Linq; // i think is needed?

namespace CLI.PoS
{
	internal class AssignmentMenuHelper
	{
		public void PrintAssignmentMenu(Course course)
		{
			bool running = true;

			while (running)
			{
				Console.WriteLine("1. Add Assignment");
				Console.WriteLine("2. Edit Assignment");
				Console.WriteLine("3. Delete Assignment");
				Console.WriteLine("4. Grade Submissions");
				Console.WriteLine("0. Back");

				var choice = Console.ReadLine();
				if (int.TryParse(choice, out int choiceInt))
				{
					switch (choiceInt)
					{
						case 1:
							AddAssignment(course);
							break;
						case 2:
							EditAssignment(course);
							break;
						case 3:
							DeleteAssignment(course);
							break;
						case 4:
							GradeSubmissions(course);
							break;
						case 0:
							return;
						default:
							Console.WriteLine("Unknown choice.");
							break;
					}
				}
			}
		}

		private void AddAssignment(Course course)
		{
			Console.Write("Name: ");
			var name = Console.ReadLine();

			Console.Write("Description: ");
			var description = Console.ReadLine();

			Console.Write("Available Points: ");
			int points = int.Parse(Console.ReadLine());

			Console.Write("Due Date: ");
			DateTime dueDate = DateTime.Parse(Console.ReadLine());

			var assignment = new Assignment
			{
				Id = course.Assignments.Count + 1,
				Name = name,
				Description = description,
				AvailablePoints = points,
				DueDate = dueDate
			};

			course.Assignments.Add(assignment);
			Console.WriteLine("Assignment added.");
		}

		private void EditAssignment(Course course)
		{
			Console.Write("Assignment Id: ");
			int id = int.Parse(Console.ReadLine()!);

			var assignment = course.Assignments.FirstOrDefault(a => a.Id == id);
			if (assignment == null)
			{
				Console.WriteLine("Assignment not found.");
				return;
			}

			Console.Write("New name (leave blank to keep): ");
			var name = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(name))
				assignment.Name = name;

			Console.Write("New description (leave blank to keep): ");
			var desc = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(desc))
				assignment.Description = desc;

			Console.Write("New points (leave blank to keep): ");
			var points = Console.ReadLine();
			if (int.TryParse(points, out int p))
				assignment.AvailablePoints = p;

			Console.WriteLine("Assignment updated.");
		}

		private void DeleteAssignment(Course course)
		{
			if (course.Assignments.Count == 0)
			{
				Console.WriteLine("No assignments to delete.");
				return;
			}

			Console.WriteLine("Assignments:");
			foreach (var a in course.Assignments)
			{
				Console.WriteLine($"{a.Id}: {a.Name}");
			}

			Console.Write("Enter Assignment Id to delete: ");
			if (!int.TryParse(Console.ReadLine(), out int id))
			{
				Console.WriteLine("Invalid input.");
				return;
			}

			var assignment = course.Assignments.FirstOrDefault(a => a.Id == id);
			if (assignment == null)
			{
				Console.WriteLine("Assignment not found.");
				return;
			}

			course.Assignments.Remove(assignment);
			Console.WriteLine("Assignment and all submissions deleted.");
		}

		private void GradeSubmissions(Course course)
		{
			if (course.Assignments.Count == 0)
			{
				Console.WriteLine("No assignments available.");
				return;
			}

			Console.WriteLine("Assignments:");
			foreach (var a in course.Assignments)
			{
				Console.WriteLine($"{a.Id}: {a.Name}");
			}

			Console.Write("Select Assignment Id: ");
			if (!int.TryParse(Console.ReadLine(), out int assignmentId))
			{
				Console.WriteLine("Invalid input.");
				return;
			}

			var assignment = course.Assignments.FirstOrDefault(a => a.Id == assignmentId);
			if (assignment == null)
			{
				Console.WriteLine("Assignment not found.");
				return;
			}

			if (assignment.Submissions.Count == 0)
			{
				Console.WriteLine("No submissions yet.");
				return;
			}

			Console.WriteLine("\nSubmissions:");
			foreach (var s in assignment.Submissions)
			{
				Console.WriteLine(
					$"Id: {s.Id} | Student: {s.StudentId} | Submitted: {s.SubmissionDate} | Grade: {s.Grade ?? "Not graded"}"
				);
			}

			Console.Write("\nSelect Submission Id to grade: ");
			if (!int.TryParse(Console.ReadLine(), out int submissionId))
			{
				Console.WriteLine("Invalid input.");
				return;
			}

			var submission = assignment.Submissions
				.FirstOrDefault(s => s.Id == submissionId);

			if (submission == null)
			{
				Console.WriteLine("Submission not found.");
				return;
			}

			Console.WriteLine("\n--- Submission Content ---");
			Console.WriteLine(submission.Content);
			Console.WriteLine("--------------------------");

			Console.Write("Enter grade: ");
			submission.Grade = Console.ReadLine();

			Console.WriteLine("Submission graded successfully.");
		}
	}
}