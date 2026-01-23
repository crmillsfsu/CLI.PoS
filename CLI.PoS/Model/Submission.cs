using System;

namespace CLI.PoS.Model
{
	public class Submission
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int AssignmentId { get; set; }
		public string? Content { get; set; }
		public DateTime SubmissionDate { get; set; }
	}
}