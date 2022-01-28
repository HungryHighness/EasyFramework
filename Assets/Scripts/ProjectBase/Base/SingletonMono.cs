using System;
using UnityEngine;

namespace Scripts.ProjectBase.Base
{
    public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T GetInstance()
        {
            return _instance;
        }

        protected void Awake()
        {
            _instance = this as T;
            DontDestroyOnLoad(this);
        }
    }
}