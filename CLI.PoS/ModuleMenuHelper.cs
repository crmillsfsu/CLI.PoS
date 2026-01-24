using CLI.PoS.Model;
using System;
using System.Linq; // for the thing i dont get right now

namespace CLI.PoS
{
	internal class ModuleMenuHelper
	{
		public void PrintModuleMenu(Course course)
		{
			bool running = true;

			while (running)
			{
				Console.WriteLine("\nModule Menu:");
				Console.WriteLine("1. Add module");
				Console.WriteLine("2. Edit module content");
				Console.WriteLine("3. Remove module");
				Console.WriteLine("0. Back");

				switch (Console.ReadLine())
				{
					case "1":
						AddModule(course);
						break;
					case "2":
						EditModuleContent(course);
						break;
					case "3":
						RemoveModule(course);
						break;
					case "0":
						running = false;
						break;
					default:
						Console.WriteLine("Invalid option.");
						break;
				}
			}
		}

		private void AddModule(Course course)
		{
			var module = new Module
			{
				Id = course.Modules.Count + 1
			};

			course.Modules.Add(module);
			Console.WriteLine($"Module {module.Id} added.");
		}

		private void EditModuleContent(Course course)
		{
			if (course.Modules.Count == 0)
			{
				Console.WriteLine("No modules available.");
				return;
			}

			Console.WriteLine("Enter Module Id:");
			int id = int.Parse(Console.ReadLine()!);

			var module = course.Modules.FirstOrDefault(m => m.Id == id); // not sure what this is
			if (module == null)
			{
				Console.WriteLine("Module not found.");
				return;
			}

			Console.WriteLine("\n1. Add content");
			Console.WriteLine("2. Edit content");
			Console.WriteLine("3. Remove content");

			switch (Console.ReadLine())
			{
				case "1":
					Console.Write("New content: ");
					module.Content.Add(Console.ReadLine()!);
					break;

				case "2":
					if (module.Content.Count == 0)
					{
						Console.WriteLine("No content to edit.");
						break;
					}

					PrintContent(module);
					Console.Write("Index to edit: ");

					if (!int.TryParse(Console.ReadLine(), out int editIndex) ||
						editIndex < 0 || editIndex >= module.Content.Count)
					{
						Console.WriteLine("Invalid index.");
						break;
					}

					Console.Write("New value: ");
					module.Content[editIndex] = Console.ReadLine()!;
					Console.WriteLine("Content updated.");
					break;

				case "3":
					if (module.Content.Count == 0)
					{
						Console.WriteLine("No content to remove.");
						break;
					}

					PrintContent(module);
					Console.Write("Index to remove: ");

					if (!int.TryParse(Console.ReadLine(), out int removeIndex) ||
						removeIndex < 0 || removeIndex >= module.Content.Count)
					{
						Console.WriteLine("Invalid index.");
						break;
					}

					module.Content.RemoveAt(removeIndex);
					Console.WriteLine("Content removed.");
					break;
			}
		}

		private void PrintContent(Module module)
		{
			for (int i = 0; i < module.Content.Count; i++)
			{
				Console.WriteLine($"{i}: {module.Content[i]}");
			}
		}

		private void RemoveModule(Course course)
		{
			Console.Write("Module Id to remove: ");
			int id = int.Parse(Console.ReadLine()!);

			var module = course.Modules.FirstOrDefault(m => m.Id == id);
			if (module != null)
			{
				course.Modules.Remove(module);
				Console.WriteLine("Module removed.");
			}
		}
	}
}