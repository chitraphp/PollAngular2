using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PollAngular2.Data;
using PollAngular2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace PollAngular2.Controllers
{
	[Produces("application/json")]
	[Route("[controller]")]
	public class PollController:Controller
	{
		private readonly PollContext _pollContext;


		public PollController(PollContext pollContext)
		{
			_pollContext = pollContext;

		}
		[HttpGet]

		public async Task<ActionResult> Poll()
		{
			var items = await _pollContext.Polls.ToListAsync();
			return Ok(items);
		}

		[HttpPost]
		[Route("newQuestion")]
		public async Task<ActionResult> PollQuestion( PollQuestion pollQuestion)
		{
			if (ModelState.IsValid)
			{
				var newPoll = new PollQuestion()
				{
					Question = pollQuestion.Question,
					Status = pollQuestion.Status,
					Voted = pollQuestion.Voted

				};
				_pollContext.Polls.Add(newPoll);
				await _pollContext.SaveChangesAsync();

				return Ok(newPoll);

			}
			else
			{
				return BadRequest();
			}
			
		}

		[HttpPost]
		[Route("newChoice")]
		public async Task<ActionResult> PollChoice( PollChoice newChoice)
		{
			if (ModelState.IsValid)
			{
				
				_pollContext.PollChoices.Add(newChoice);
				await _pollContext.SaveChangesAsync();

				return Ok(newChoice);

			}
			else
			{
				return BadRequest();
			}

		}

		//[HttpPost]
		//[Route("newPoll")]
		//public async Task<ActionResult> newPoll1([FromBody] JObject jObject)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		PollQuestion pollQuestion = jObject["question"].ToObject<PollQuestion>();
		//		var newPoll = new PollQuestion()
		//		{
		//			Question = pollQuestion.Question,
		//			Status = pollQuestion.Status,
		//			Voted = pollQuestion.Voted

		//		};
								
		//		IActionResult actionResult =await  PollQuestion(newPoll);
		//		OkObjectResult okResult = actionResult as OkObjectResult;
		//		PollQuestion question = (PollQuestion)okResult.Value;
		//		var str=jObject["choices"].ToObject<PollChoice>().ToString();


		//		JObject o = JObject.Parse((string)jObject["choices"]);

		//		JArray a = (JArray)o["Choices"];

		//		IList<PollChoice> choices = a.ToObject<IList<PollChoice>>();
		//		foreach(var choice in choices)
		//		{
		//			var newChoice = new PollChoice()
		//			{
		//				Choice = choice.Choice,
		//				Votes = choice.Votes,
		//				PollId = question.PollId

		//			};
		//			await PollChoice(choice);
		//		}
		//		return Ok();

		//	}
		//	else
		//	{
		//		return BadRequest();
		//	}

		//}

		[HttpPost]
		[Route("newPoll")]
		public async Task<ActionResult> newPoll([FromBody] PollModel pollModel)
		{
			
			if (ModelState.IsValid)
			{
				PollQuestion pollQuestion = pollModel.Question;
				var newPoll = new PollQuestion()
				{
					Question = pollQuestion.Question,
					Status = pollQuestion.Status,
					Voted = pollQuestion.Voted

				};

				IActionResult actionResult = await PollQuestion(newPoll);
				OkObjectResult okResult = actionResult as OkObjectResult;
				PollQuestion question = (PollQuestion)okResult.Value;

				IList<PollChoice> pollChoices = new List<PollChoice>();
				pollChoices = pollModel.ListOfChoices;
				foreach(PollChoice choice in pollChoices)
				{
					var newChoice = new PollChoice()
					{
						Choice = choice.Choice,
						Votes = choice.Votes,
						PollId = question.PollId

					};
					await PollChoice(newChoice);
				}
				
				return Ok();

			}
			else
			{
				return BadRequest();
			}

		}

	}
}
