using Api.Services.EventGridEventGridPublisher;

namespace Api.Services.EventGridPublisher
{
    public interface IEventGridPublisher
    {
        Task<bool> ExecuteTopicAsync(EventGridPublisherTopicRequest request, CancellationToken cancellationToken);
        Task<bool> ExecuteDomainAsync(EventGridPublisherDomainRequest request, CancellationToken cancellationToken);
    }
}
