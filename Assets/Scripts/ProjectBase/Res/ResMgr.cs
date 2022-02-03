using System.Collections;
using ProjectBase.Mono;
using Scripts.ProjectBase.Base;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectBase.Res
{
    public class ResMgr : BaseManager<ResMgr>
    {
        public T Load<T>(string name) where T : Object
        {
            T res = Resources.Load<T>(name);
            if (res is GameObject)
            {
                return GameObject.Instantiate(res);
            }
            else
            {
                return res;
            }
        }

        public void LoadAsync<T>(string name, UnityAction<T> callback) where T : Object
        {
            MonoMgr.GetInstance().StartCoroutine(ReallyLoadAsync<T>(name, callback));
        }

        private IEnumerator ReallyLoadAsync<T>(string name, UnityAction<T> callback) where T : Object
        {
            ResourceRequest request = Resources.LoadAsync<T>(name);
            yield return request;
            if (request.asset is GameObject)
            {
                callback(GameObject.Instantiate(request.asset) as T);
            }
            else
            {
                callback(request.asset as T);
            }
        }
    }
}