using System;

namespace ProEventos.API.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string Local { get; set; }
        public string Date { get; set; }
        public string Theme { get; set; }
        public int PeopleAmount { get; set; }
        public string Lot { get; set; }
        public string ImageUrl { get; set; }

    }
}
