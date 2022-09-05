using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Local { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public int PeopleAmount { get; set; }
        public string ImageUrl { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<SocialMedia> SocialMedia { get; set; }
        public IEnumerable<PanelistEvent> PanelistEvent { get; set; }

    }
}
