using System;
using System.Collections.Generic;
using System.Text;

namespace CLI.PoS
{
    internal class StudentMenuHelper
    {
        public void PrintStudentMenu()
        {
			bool running = true;

			while (running)
			{
				Console.WriteLine("\Course Name and Code Here(temp):");
				Console.WriteLine("1. See all modules and module content");
				Console.WriteLine("2. See all assignments");
				Console.WriteLine("3. See other students in the course");
				Console.WriteLine("4. See course schedule");
				Console.WriteLine("5. Submit Assignment");
				Console.WriteLine("6. Unenroll");
				Console.WriteLine("0. Exit to main menu");

				var choice = Console.ReadLine();
				if (int.TryParse(choice, out int choiceInt))
				{
					switch (choiceInt)
					{
						case 1:
							CourseContent();
							break;
						case 2:
							DisplayAssignments();
							break;
						case 3:
							StudentRoster();
							break;
						case 4:
							CourseScheduleMenu();
							break;
						case 5:
							SubmitAssignment();
							break;
						case 6:
							UnenrollStudent();
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
    }
}