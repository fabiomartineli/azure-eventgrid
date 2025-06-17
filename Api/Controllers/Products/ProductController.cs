using Api.Database;
using Api.Entities;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.SystemEvents;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net;

namespace Api.Controllers.Products
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private const string EVENT_VALIDATION_NAME = "Microsoft.EventGrid.SubscriptionValidationEvent";

        [HttpPost("webhook")]
        public async Task<IActionResult> Webhook([FromServices] ILogger<ProductController> logger,
            [FromBody] List<EventGridEvent> events,
            [FromServices] IDatabaseContext database,
             CancellationToken cancellationToken)
        {
            logger.LogInformation("Receiving {Path} event...", HttpContext.Request.Path.Value);

            foreach (var @event in events)
            {
                if (@event.EventType.Equals(EVENT_VALIDATION_NAME)) // WHEN THE REQUEST IS TO CONFIRM THE ENDPOINT SUBSCRIPTION OWNER
                {
                    var validation = @event.Data.ToObjectFromJson<SubscriptionValidationEventData>();
                    return Ok(new { validationResponse = validation.ValidationCode });
                }

                var entity = @event.Data.ToObjectFromJson<Product>();
                entity.SetEvent(HttpContext.Request.Path.Value);
                entity.SetMachine(Dns.GetHostName());

                var filter = Builders<Product>.Filter.Eq(x => x.Name, entity.Name);
                await database.GetCollection<Product>("products").ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true }, cancellationToken);
            }

            return Ok();
        }
    }
}
