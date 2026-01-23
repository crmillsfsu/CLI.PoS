using System.Collections.Generic;

namespace CLI.PoS.Model
{
	public class Module
	{
		public int Id { get; set; }
		public List<string> Content { get; set; } = new();
	}
}