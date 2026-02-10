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

		public double? Grade { get; set; }
		public string Comment { get; set; }
		public double? PointsEarned { get; set; }   // null = not graded yet
		public string? Feedback { get; set; }
	}
}