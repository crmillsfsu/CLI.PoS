using System.Collections.Generic;

namespace CLI.PoS.Model
{
	public class Course
	{
		public int Id { get; set; }
		public string? Code { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string Semester { get; set; }
		public string Section { get; set; }

		public List<Student> Roster { get; set; } = new();
		public List<Module> Modules { get; set; } = new();
		public List<Assignment> Assignments { get; set; } = new();
		public List<AssignmentGroup> AssignmentGroups { get; set; } = new();

		public double GetStudentAverage(int studentId)
		{
			double totalWeightedScore = 0;
			double totalWeight = 0;

			foreach (var group in AssignmentGroups)
			{
				double groupScore = 0;
				double groupMax = 0;

				var groupAssignments = Assignments
					.Where(a => a.GroupId == group.Id);

				foreach (var assignment in groupAssignments)
				{
					var submission = assignment.Submissions
						.FirstOrDefault(s => s.StudentId == studentId);

					if (submission?.PointsEarned != null)
					{
						groupScore += submission.PointsEarned.Value;
						groupMax += assignment.AvailablePoints;
					}
				}

				if (groupMax > 0)
				{
					double groupPercent = groupScore / groupMax;

					totalWeightedScore += groupPercent * group.Weight;
					totalWeight += group.Weight;
				}
			}

			if (totalWeight == 0)
				return 0;

			return totalWeightedScore / totalWeight * 100;
		}

		public double GetStudentAverage(int studentId)
		{
			double totalWeightedScore = 0;
			double totalWeight = 0;

			foreach (var group in AssignmentGroups)
			{
				double groupScore = 0;
				double groupMax = 0;

				var groupAssignments = Assignments
					.Where(a => a.GroupId == group.Id);

				foreach (var assignment in groupAssignments)
				{
					var submission = assignment.Submissions
						.FirstOrDefault(s => s.StudentId == studentId);

					if (submission?.PointsEarned != null)
					{
						groupScore += submission.PointsEarned.Value;
						groupMax += assignment.AvailablePoints;
					}
				}

				if (groupMax > 0)
				{
					double groupPercent = groupScore / groupMax;

					totalWeightedScore += groupPercent * group.Weight;
					totalWeight += group.Weight;
				}
			}

			if (totalWeight == 0)
				return 0;

			return totalWeightedScore / totalWeight * 100;
		}

		public Dictionary<string, double?> GetStudentAssignmentGrades(int studentId)
		{
			var result = new Dictionary<string, double?>();

			foreach (var assignment in Assignments)
			{
				var submission = assignment.Submissions
					.FirstOrDefault(s => s.StudentId == studentId);

				if (submission?.PointsEarned != null)
				{
					result[assignment.Name] =
						submission.PointsEarned.Value / assignment.AvailablePoints * 100;
				}
				else
				{
					result[assignment.Name] = null;
				}
			}

			return result;
		}

	}
}