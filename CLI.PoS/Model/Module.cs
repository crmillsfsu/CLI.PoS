using System.Collections.Generic;

namespace CLI.PoS.Model
{
	public class Module
	{
		public int Id { get; set; }
		public List<ModuleContent> Content { get; set; } = new();
	}
}