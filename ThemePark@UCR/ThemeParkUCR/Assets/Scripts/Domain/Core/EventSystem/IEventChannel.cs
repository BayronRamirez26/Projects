using System;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem
{
    /// <summary>
    /// Interface that represents an event channel. 
    /// An event channel is a way to communicate between different 
    /// parts of the application.
    /// And it is the bus to trigger events and notify subscribers.
    /// </summary>
    public interface IEventChannel
    {
        /// <summary>
        /// Fire an event. This means that all the subscribers to this event will be notified.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        public void Fire<TEvent>(TEvent @event)
            where TEvent : IEvent; // This is a constraint. It means that TEvent must implement IEvent.

        /// <summary>
        /// Subscribe to an event. This means that when the event is fired, the callback will be executed.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="eventCallback"></param>
        public void Subscribe<TEvent>(Action<TEvent> eventCallback) // Action is a delegate that represents a method that takes no parameters and returns void.
            where TEvent : IEvent;

        /// <summary>
        /// Unsubscribe from an event. This means that the callback will no longer be executed when the event is fired.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="eventCallback"></param>
        public void Unsubscribe<TEvent>(Action<TEvent> eventCallback)
            where TEvent : IEvent;
    }
}
