using System;

namespace ProEventos.Domain
{
    public class PanelistEvent
    {
        public Guid Id { get; set; }
        public Guid PanelistId { get; set; }
        public Panelist Panelist { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}