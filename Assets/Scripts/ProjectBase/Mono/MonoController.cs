using System;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectBase.Mono
{
    public class MonoController : MonoBehaviour
    {
        private event UnityAction _updateEvent;

        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        private void Update()
        {
            if (_updateEvent != null)
            {
                _updateEvent.Invoke();
            }
        }

        public void AddUpdateListener(UnityAction fun)
        {
            _updateEvent += fun;
        }

        public void RemoveUpdateListener(UnityAction fun)
        {
            _updateEvent -= fun;
        }
        
      
    }
}