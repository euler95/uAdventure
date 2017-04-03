using System;
using uAdventure.Core;

namespace uAdventure.Minigame
{
	public class Minigame : HasId, Documented
	{
		public Minigame(string id)
		{
			Id = id;
			Conditions = new Conditions();
			Effects = new Effects();
		}


		public string Id { get; set; }

		public string Documentation { get; set; }

		public string Content { get; set; }

		public Conditions Conditions { get; set; }
		public Effects Effects { get; set; }

		public string getDocumentation()
		{
			return Documentation;
		}

		public string getId()
		{
			return Id;
		}

		public void setDocumentation(string documentation)
		{
			Documentation = documentation;
		}

		public void setId(string id)
		{
			Id = id;
		}
	}
}