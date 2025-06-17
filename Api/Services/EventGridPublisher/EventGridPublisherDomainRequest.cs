namespace Api.Services.EventGridEventGridPublisher
{
    public sealed record EventGridPublisherDomainRequest
    {
        public required string Id { get; init; }
        public required string Version { get; init; }
        public required string Type { get; init; }
        public required string Topic { get; init; }
        public required object Content { get; init; }
        public string ContentType { get; init; }
        public string Subject { get; init; }
    }
}
