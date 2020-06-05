using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAngular2.Model
{
	public class PollQuestion
	{
		public int PollId { get; set; }
		public string Question { get; set; }
		public int Voted { get; set; }
		public string Status { get; set; }
	}
}
