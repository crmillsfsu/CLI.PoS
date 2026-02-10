namespace CLI.PoS.Model
{
	public abstract class ModuleContent
	{
		public int Id { get; set; }
		public string Title { get; set; }

		// Forces all items to know how to display themselves
		public abstract void Display();

		public abstract ModuleContent Clone();
	}
}