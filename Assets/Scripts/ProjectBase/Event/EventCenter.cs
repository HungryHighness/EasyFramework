using System.Collections.Generic;
using Scripts.ProjectBase.Base;
using UnityEngine.Events;

namespace ProjectBase.Event
{
    public class EventCenter : BaseManager<EventCenter>
    {
        private Dictionary<string, IEventInfo> _eventDic = new Dictionary<string, IEventInfo>();

        public void AddEventListener(string name, UnityAction action)
        {
            if (_eventDic.ContainsKey(name))
            {
                (_eventDic[name] as EventInfo).actions += action;
            }
            else
            {
                _eventDic.Add(name, new EventInfo(action));
            }
        }

        public void AddEventListener<T>(string name, UnityAction<T> action)
        {
            if (_eventDic.ContainsKey(name))
            {
                (_eventDic[name] as EventInfo<T>).actions += action;
            }
            else
            {
                _eventDic.Add(name, new EventInfo<T>(action));
            }
        }

        public void RemoveEventListener(string name, UnityAction action)
        {
            if (_eventDic.ContainsKey(name))
            {
                (_eventDic[name] as EventInfo).actions -= action;
            }
        }

        public void RemoveEventListener<T>(string name, UnityAction<T> action)
        {
            if (_eventDic.ContainsKey(name))
            {
                (_eventDic[name] as EventInfo<T>).actions -= action;
            }
        }

        public void EventTrigger(string name)
        {
            if (_eventDic.ContainsKey(name))
            {
                (_eventDic[name] as EventInfo)?.actions.Invoke();
            }
        }

        public void EventTrigger<T>(string name, T info)
        {
            if (_eventDic.ContainsKey(name))
            {
                (_eventDic[name] as EventInfo<T>)?.actions.Invoke(info);
            }
        }

        public void Clear()
        {
            _eventDic.Clear();
        }
    }
}