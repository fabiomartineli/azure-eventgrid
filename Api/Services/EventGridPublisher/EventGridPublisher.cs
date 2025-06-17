using Api.Services.EventGridEventGridPublisher;
using Azure;
using Azure.Messaging.EventGrid;

namespace Api.Services.EventGridPublisher
{
    public class EventGridPublisher : IEventGridPublisher
    {
        private readonly EventGridPublisherClient _client;

        public EventGridPublisher(string accessKey, string endpoint)
        {
            _client = new EventGridPublisherClient(new Uri(endpoint), new AzureKeyCredential(accessKey));
        }

        public async Task<bool> ExecuteTopicAsync(EventGridPublisherTopicRequest request, CancellationToken cancellationToken)
        {
            var @event = new EventGridEvent(request.Subject, request.Type, request.Version, request.Content)
            {
                Id = request.Id,
                Subject = request.Subject,
                EventTime = DateTimeOffset.UtcNow,
            };
            var response = await _client.SendEventsAsync([@event], cancellationToken);

            return !response.IsError;
        }

        public async Task<bool> ExecuteDomainAsync(EventGridPublisherDomainRequest request, CancellationToken cancellationToken)
        {
            var @event = new EventGridEvent(request.Subject, request.Type, request.Version, request.Content)
            {
                Id = request.Id,
                Subject = request.Subject,
                EventTime = DateTimeOffset.UtcNow,
                Topic = request.Topic,
            };
            var response = await _client.SendEventsAsync([@event], cancellationToken);

            return !response.IsError;
        }
    }
}
