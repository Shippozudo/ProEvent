using ProEventos.Domain;
using ProEvents.Application.Repository;
using ProEvents.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProEvents.Application
{
    public class EventService : IEventService
    {
        private readonly IRepositoryPersistence _repository;
        private readonly IEventPersistence _eventRepository;

        public EventService(IRepositoryPersistence repository, IEventPersistence eventRepository)
        {
            _repository = repository;
            _eventRepository = eventRepository;
        }

        public async Task<Event> AddEvent(Event entity)
        {
            try
            {
                await _repository.Add<Event>(entity);
                await _repository.CommitAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> UpdateEvent(Guid id, Event entity)
        {
            try
            {
                var getEvent = await _eventRepository.GetEventByIdAsync(id);
                entity.Id = getEvent.Id;
                await _repository.Update<Event>(entity);
                await _repository.CommitAsync();
                return getEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> DeleteEvent(Guid id)
        {
            try
            {
                var getEvent = await _eventRepository.GetEventByIdAsync(id);
                await _repository.Delete<Event>(getEvent);
                await _repository.CommitAsync();
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(Guid id)
        {
            try
            {
                var getEvent = await _eventRepository.GetEventByIdAsync(id);
                return getEvent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            try
            {
                var getEvents = await _eventRepository.GetAllEventsAsync();
                return getEvents ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Event>> GetAllEventsByThemeAsync(string theme)
        {
            try
            {
                var getEvents = await _eventRepository.GetAllEventsByThemeAsync(theme);
                return getEvents ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
    }
}
