namespace ASP.NET.crud.Entities
{
    public class DevEvents
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DevEventSpeaker> Speaker { get; set; }
        public bool isDeleted { get; set; }

        public void Update(string title, string description, DateTime startdate, DateTime endtime)
        {
            Title = title;
            Description = description;
            StartDate = startdate;
            EndDate = endtime;
        }
        public void Delete()
        {
            isDeleted = true;
        }

    }
}



