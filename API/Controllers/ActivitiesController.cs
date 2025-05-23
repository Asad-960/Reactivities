using Application.Activities.Commands;
using Application.Activities.Queries;
using Application.DTOs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {


        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new GetActivityList.Query());
        }

        [HttpGet("{id}")] //api/activities/fasdal
        public async Task<ActionResult<Activity>> GetActivity(string id)
        {
            // throw new Exception("Test exception"); // for testing error handling
            return HandleResult(await Mediator.Send(new GetActivityDetails.Query { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(CreateActivityDto activityDto)
        {
            return HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto }));
        }

        [HttpPut]
        public async Task<ActionResult> EditActivity(EditActivityDto activityDto)
        {
            return HandleResult(await Mediator.Send(new EditActivity.Command { ActivityDto = activityDto }));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteActivity(string id)
        {
            return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id }));
        }
    }
}