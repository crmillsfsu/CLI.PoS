namespace CLI.PoS.Model
{
	public class ModulePage : ModuleContent
	{
		public string Content { get; set; }

		public override void Display()
		{
			Console.WriteLine($"[Page] {Title}");
			Console.WriteLine(Content);
		}

		public override ModuleContent Clone()
		{
			return new ModulePage
			{
				Id = Id,
				Title = Title,
				Content = Content
			};
		}

	}
}
