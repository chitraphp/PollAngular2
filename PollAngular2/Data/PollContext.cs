using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollAngular2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAngular2.Data
{
	public class PollContext:DbContext
	{
		public PollContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<PollQuestion> Polls { get; set; }
		public DbSet<PollChoice> PollChoices { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<PollQuestion>(ConfigurePoll);
			builder.Entity<PollChoice>(ConfigurePollChoice);
			//builder.Entity<Poll>(ConfigurePoll);
		}

		private void ConfigurePollChoice(EntityTypeBuilder<PollChoice> builder)
		{
			builder.ToTable("PollChoice");
			builder.HasKey(c => c.ChoiceId);
			//builder.Property(c => c.ChoiceId).UseHiLo("Poll-Choice").IsRequired();
			builder.Property(c => c.Choice).HasMaxLength(100).IsRequired();
			builder.Property(c => c.Votes).IsRequired();
			builder.HasOne(c => c.Poll).WithMany().HasForeignKey(c => c.PollId);
		}

		private void ConfigurePoll(EntityTypeBuilder<PollQuestion> builder)
		{
			builder.ToTable("Poll");
			//builder.Property(c => c.PollId)
			//	.UseHiLo("poll-hilo")
			//	.IsRequired();
			builder.HasKey(c => c.PollId);
			builder.Property(c => c.Question)
				.IsRequired().HasMaxLength(500);
			builder.Property(c => c.Voted)
				.IsRequired();
			builder.Property(c => c.Status).IsRequired().HasMaxLength(20);
			//builder.HasOne(c => c.Option).WithMany().HasForeignKey(c => c.OptionId);
		}

		//private void ConfigurePollOption(EntityTypeBuilder<PollOption> builder)
		//{
		//	builder.ToTable("PollOption");
		//	builder.Property(c => c.OptionId).UseHiLo("option-hilo").IsRequired();
		//	builder.Property(c => c.OptionString)
		//		.IsRequired().HasMaxLength(100);
		//	builder.Property(c => c.Votes)
		//		.IsRequired();
		//	builder.HasOne(c => c.Poll).WithMany().HasForeignKey(c => c.PollId);
		//	//builder.HasNoKey();

		//}

	}
}
