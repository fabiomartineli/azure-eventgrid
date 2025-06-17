namespace Api.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public string MachineName { get; private set; }
        public string EventType { get; private set; }

        public void SetMachine(string machineName) => MachineName = machineName;
        public void SetEvent(string eventType) => EventType = eventType;
    }
}
