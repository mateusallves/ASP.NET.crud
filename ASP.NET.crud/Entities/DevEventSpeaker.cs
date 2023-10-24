namespace ASP.NET.crud.Entities
{
    public class DevEventSpeaker
    {
        public Guid Id { get; set; }
        public string TalkTitle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkdinProfile { get; set; }
        public Guid DevEventId { get; set; }
    }

}


