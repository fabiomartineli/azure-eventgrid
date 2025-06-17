namespace Api.Services.EventGridEventGridPublisher
{
    public sealed record EventGridPublisherTopicRequest
    {
        public required string Id { get; init; }
        public required string Version { get; init; }
        public required string Type { get; init; }
        public required string Source { get; init; }
        public required object Content { get; init; }
        public string ContentType { get; init; }
        public string Subject { get; init; }
    }
}
