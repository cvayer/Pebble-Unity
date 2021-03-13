using System;
using System.Collections.Generic;

//--------------------------------------------------------
//--------------------------------------------------------
// EventManager
//--------------------------------------------------------
//--------------------------------------------------------
namespace Pebble
{
    public class EventManager : Singleton<EventManager>
    {
        public delegate void EventDelegate<T>(T evt) where T : Event;

        private Dictionary<Type, Delegate>[] m_listeners;

        public EventManager()
        {
            m_listeners = new Dictionary<Type, Delegate>[(int)EventChannel.Count];

            for (int channel = 0; channel < (int)EventChannel.Count; ++channel)
            {
                m_listeners[channel] = new Dictionary<Type, Delegate>();
            }
        }

        //--------------------------------------------------------
        public static void Subscribe<T>(EventDelegate<T> callback, EventChannel channel = EventChannel.Regular) where T : Event
        {
            if (Instance != null)
            {
                Instance.OnSubscribe<T>(callback, channel);
            }

        }

        //--------------------------------------------------------
        public static void UnSubscribe<T>(EventDelegate<T> callback, EventChannel channel = EventChannel.Regular) where T : Event
        {
            if (Instance != null)
            {
                Instance.OnUnSubscribe<T>(callback, channel);
            }
        }

        //--------------------------------------------------------
        // Automatically free the event if inherit from PooledEvent
        public static void SendEvent<T>(T evt) where T : Event
        {
            if (Instance != null)
            {
                Instance.OnSendEvent<T>(evt);
            }
        }

        //--------------------------------------------------------
        // Automatically free the event if inherit from PooledEvent
        public static void SendEmptyPooledEvent<T>() where T : PooledEvent, new()
        {
            if (Instance != null)
            {
                T evt = Pools.Claim<T>();
                Instance.OnSendEvent<T>(evt);
            }
        }

        //--------------------------------------------------------
        private void OnSubscribe<T>(EventDelegate<T> callback, EventChannel channel) where T : Event
        {
            if (channel == EventChannel.Count)
                return;

            int intChannel = (int)channel;
            Type type = typeof(T);
            Delegate existingDelegate;
            if (m_listeners[intChannel].TryGetValue(type, out existingDelegate))
            {
                EventDelegate<T> existingEventDelegate = existingDelegate as EventDelegate<T>;
                existingEventDelegate += callback;
                m_listeners[intChannel][type] = existingEventDelegate;
            }
            else
            {
                m_listeners[intChannel][type] = callback;
            }
        }

        //--------------------------------------------------------
        private void OnUnSubscribe<T>(EventDelegate<T> callback, EventChannel channel) where T : Event
        {
            if (channel == EventChannel.Count)
                return;

            int intChannel = (int)channel;
            Type type = typeof(T);
            Delegate existingDelegate;
            if (m_listeners[intChannel].TryGetValue(type, out existingDelegate))
            {
                EventDelegate<T> existingEventDelegate = existingDelegate as EventDelegate<T>;
                existingEventDelegate -= callback;
                if (existingEventDelegate == null)
                {
                    m_listeners[intChannel].Remove(type);
                }
                else
                {
                    m_listeners[intChannel][type] = existingEventDelegate;
                }
            }
        }

        //--------------------------------------------------------
        public void OnSendEvent<T>(T evt) where T : Event
        {
            Type type = evt.GetType();
            Delegate existingDelegate;

            for (int channel = 0; channel < (int)EventChannel.Count; ++channel)
            {
                if (m_listeners[channel].TryGetValue(type, out existingDelegate))
                {
                    EventDelegate<T> existingEventDelegate = existingDelegate as EventDelegate<T>;
                    if (existingEventDelegate != null)
                    {
                        existingEventDelegate(evt);
                    }
                    /*
                    else
                    {
                        existingDelegate.DynamicInvoke(evt);
                    }  */
                }
            }

            PooledEvent pooledEvent = evt as PooledEvent;
            if (pooledEvent != null)
            {
                Pools.Free(pooledEvent);
            }
        }
    }
}

