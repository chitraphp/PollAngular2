using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAngular2.Model
{
	public class PollOption
	{
		public int OptionId { get; set; }
		public string OptionString { get; set; }
		public int Votes { get; set; }
		public int PollId { get; set; }
		public virtual PollQuestion Poll { get; set; }
	}
}
