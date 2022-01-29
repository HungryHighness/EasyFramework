using UnityEngine.Events;

namespace ProjectBase.Event
{
    public class EventInfo : IEventInfo
    {
        public UnityAction actions;

        public EventInfo(UnityAction unityAction)
        {
            actions += unityAction;
        }
    }

    public class EventInfo<T> : IEventInfo
    {
        public UnityAction<T> actions;

        public EventInfo(UnityAction<T> unityAction)
        {
            actions += unityAction;
        }
    }
}