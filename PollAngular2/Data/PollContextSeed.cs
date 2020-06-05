using Microsoft.EntityFrameworkCore;
using PollAngular2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAngular2.Data
{
	public class PollContextSeed
	{
        public static async Task SeedAsync(PollContext context)
        {
            context.Database.Migrate();

            

            if (!context.Polls.Any())
            {
                context.Polls.AddRange
                    (GetPreconfiguredPolls());

                await context.SaveChangesAsync();
            }
            if (!context.PollChoices.Any())
            {
                context.PollChoices.AddRange
                    (GetPreconfiguredPollChoices());

                await context.SaveChangesAsync();
            }

        }

        private static IEnumerable<PollQuestion> GetPreconfiguredPolls()
        {
            return new List<PollQuestion>()
            {
                new PollQuestion(){Question="How is weather",Voted=0,Status="active" }

            };
        }

        private static IEnumerable<PollChoice> GetPreconfiguredPollChoices()
        {
            return new List<PollChoice>()
            {
                new PollChoice(){Choice="Yes",Votes=0,PollId=1},
                new PollChoice(){Choice="No",Votes=0,PollId=1}
            };

        }

    }
}
