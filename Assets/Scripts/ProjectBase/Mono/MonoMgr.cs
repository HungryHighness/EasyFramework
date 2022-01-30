using System.Collections;
using Scripts.ProjectBase.Base;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectBase.Mono
{
    public class MonoMgr : BaseManager<MonoMgr>
    {
        private MonoController _controller;

        public MonoMgr()
        {
            GameObject obj = new GameObject("MonoController");
            _controller = obj.AddComponent<MonoController>();
        }

        public void AddUpdateListener(UnityAction fun)
        {
            _controller.AddUpdateListener(fun);
        }

        public void RemoveUpdateListener(UnityAction fun)
        {
            _controller.RemoveUpdateListener(fun);
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return _controller.StartCoroutine(routine);
        }
    }
}