namespace CLI.PoS.Model
{
	public class ModuleAssignment : ModuleContent
	{
		public Assignment Assignment { get; set; }

		public override void Display()
		{
			Console.WriteLine($"[Assignment] {Assignment.Name}");
			Console.WriteLine($"Due: {Assignment.DueDate}");
			Console.WriteLine($"Points: {Assignment.AvailablePoints}");
		}

		public override ModuleContent Clone()
		{
			return new ModuleAssignment
			{
				Id = Id,
				Assignment = new Assignment
				{
					Id = Assignment.Id,
					Name = Assignment.Name,
					Description = Assignment.Description,
					AvailablePoints = Assignment.AvailablePoints,
					DueDate = Assignment.DueDate,
					Submissions = new List<Submission>()
				}
			};
		}

	}
}
