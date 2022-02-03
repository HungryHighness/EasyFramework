using System.Collections;
using ProjectBase.Event;
using ProjectBase.Mono;
using Scripts.ProjectBase.Base;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace ProjectBase.Scenes
{
    public class ScenesMgr : BaseManager<ScenesMgr>
    {
        public void LoadScene(string name, UnityAction fun)
        {
            SceneManager.LoadScene(name);
            fun();
        }

        public void LoadSceneAsync(string name, UnityAction fun)
        {
            MonoMgr.GetInstance().StartCoroutine(ReallyLoadSceneAsync(name, fun));
        }

        private IEnumerator ReallyLoadSceneAsync(string name, UnityAction fun)
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync(name);
            while (ao.isDone)
            {
                EventCenter.GetInstance().EventTrigger("Loading", ao.progress);
                yield return ao.progress;
            }

            yield return ao;
            fun();
        }
    }
}