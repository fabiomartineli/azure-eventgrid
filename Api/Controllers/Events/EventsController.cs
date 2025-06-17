using Api.Services.EventGridEventGridPublisher;
using Api.Services.EventGridPublisher;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Events
{
    [ApiController]
    [Route("events")]
    public class EventsController : ControllerBase
    {
        [HttpPost("topic")]
        public async Task<IActionResult> SendTopicAsync([FromServices] IEventGridPublisher publisher,
            [FromBody] EventGridPublisherTopicRequest request,
            CancellationToken cancellationToken)
        {
            var result = await publisher.ExecuteTopicAsync(request, cancellationToken);
            
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("domain")]
        public async Task<IActionResult> SendDomainAsync([FromServices] IEventGridPublisher publisher,
            [FromBody] EventGridPublisherDomainRequest request,
            CancellationToken cancellationToken)
        {
            var result = await publisher.ExecuteDomainAsync(request, cancellationToken);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
