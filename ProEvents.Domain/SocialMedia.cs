using System;

namespace ProEventos.Domain
{
    public class SocialMedia
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid PanelistId { get; set; }
        public Panelist Panelist { get; set; }
    }
}