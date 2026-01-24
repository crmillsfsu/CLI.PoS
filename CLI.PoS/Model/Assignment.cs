using System;
using System.Collections.Generic;

namespace CLI.PoS.Model
{
	public class Assignment
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int AvailablePoints { get; set; }
		public DateTime DueDate { get; set; }

		public List<Submission> Submissions { get; set; } = new();
	}
}