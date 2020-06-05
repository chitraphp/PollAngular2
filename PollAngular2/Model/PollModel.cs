using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAngular2.Model
{
	public class PollModel
	{
		
		public PollQuestion Question { get; set; }
		public IList<PollChoice> ListOfChoices { get; set; }

	}
}
