using ProjectBase.Event;
using ProjectBase.Mono;
using Scripts.ProjectBase.Base;
using UnityEngine;

namespace ProjectBase.InputSystem
{
    public class InputMgr : BaseManager<InputMgr>
    {
        private bool _isStart = false;

        public InputMgr()
        {
            MonoMgr.GetInstance().AddUpdateListener(MyUpdate);
        }

        private void MyUpdate()
        {
            if (!_isStart)
            {
                return;
            }

            CheckKeyCode(KeyCode.W);
        }

        public void StartOrEndCheck(bool isOpen)
        {
            _isStart = isOpen;
        }

        private void CheckKeyCode(KeyCode key)
        {
            if (Input.GetKeyDown(key))
            {
                EventCenter.GetInstance().EventTrigger("某键按下", KeyCode.W);
            }

            if (Input.GetKeyUp(key))
            {
                EventCenter.GetInstance().EventTrigger("某键抬起", KeyCode.W);
            }
        }
    }
}