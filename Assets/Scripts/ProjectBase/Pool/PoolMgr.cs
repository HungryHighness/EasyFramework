using System.Collections.Generic;
using ProjectBase.Res;
using Scripts.ProjectBase.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.ProjectBase.Pool
{
    public class PoolMgr : BaseManager<PoolMgr>
    {
        public Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();

        private GameObject _poolObj;

        public void GetObj(string name, UnityAction<GameObject> callback)
        {
            GameObject obj = null;
            if (poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0)
            {
                callback(poolDic[name].GetObj());
            }
            else
            {
                ResMgr.GetInstance().LoadAsync<GameObject>(name, (obj =>
                {
                    obj.name = name;
                    callback(obj);
                }));
            }
        }

        public void PushObj(string name, GameObject obj)
        {
            if (_poolObj == null)
            {
                _poolObj = new GameObject("Pool");
            }

            if (poolDic.ContainsKey(name))
            {
                poolDic[name].PushObj(obj);
            }
            else
            {
                poolDic.Add(name, new PoolData(obj, _poolObj));
            }
        }

        public void Clear()
        {
            poolDic.Clear();
            _poolObj = null;
        }
    }
}