using System.Collections.Generic;

namespace CLI.PoS.Model
{
	public class Course
	{
		public int Id { get; set; }
		public string? Code { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }

		public List<Student> Roster { get; set; } = new();
		public List<Module> Modules { get; set; } = new();
		public List<Assignment> Assignments { get; set; } = new();
	}
}