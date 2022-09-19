using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Panelist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public Contact Contact { get; set; }
        public IEnumerable<SocialMedia> SocialMedia { get; set; }
        public IEnumerable<PanelistEvent> PanelistEvent { get; set; }
    }
}