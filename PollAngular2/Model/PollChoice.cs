using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAngular2.Model
{
	public class PollChoice
	{
		public int ChoiceId { get; set; }
		public string Choice { get; set; }
		public int Votes { get; set; }
		public int PollId { get; set; }
		public virtual PollQuestion Poll { get; set; }
	}
}
