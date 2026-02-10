namespace CLI.PoS.Model
{
	public class ModuleFile : ModuleContent
	{
		public string FileName { get; set; }
		public string FilePath { get; set; }

		public override void Display()
		{
			Console.WriteLine($"[File] {FileName}");
			Console.WriteLine($"Path: {FilePath}");
		}

		public override ModuleContent Clone()
		{
			return new ModuleFile
			{
				Id = Id,
				FileName = FileName,
				Path = Path
			};
		}

	}
}
