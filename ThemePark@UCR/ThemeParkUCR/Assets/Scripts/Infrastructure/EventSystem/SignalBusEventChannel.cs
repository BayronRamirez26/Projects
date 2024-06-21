using System;
using UCR.ECCI.PI.ThemePark_UCR.Unity.Domain.Core.EventSystem;
using Zenject;

namespace UCR.ECCI.PI.ThemePark_UCR.Unity.Infrastructure.Core.EventSystem
{
    public class SignalBusEventChannel : IEventChannel
    {
        private readonly SignalBus _signalBus;

        public SignalBusEventChannel(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Fire<TEvent>(TEvent @event) where TEvent : IEvent
        {
            _signalBus.Fire(@event);
        }

        public void Subscribe<TEvent>(Action<TEvent> eventCallback) where TEvent : IEvent
        {
            _signalBus.Subscribe(eventCallback);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> eventCallback) where TEvent : IEvent
        {
            _signalBus.Unsubscribe(eventCallback);
        }

    }
}
