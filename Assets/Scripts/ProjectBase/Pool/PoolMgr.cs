using System.Collections.Generic;
using Scripts.ProjectBase.Base;
using UnityEngine;

namespace Scripts.ProjectBase.Pool
{
    public class PoolMgr : BaseManager<PoolMgr>
    {
        public Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();

        private GameObject _poolObj;

        public GameObject GetObj(string name)
        {
            GameObject obj = null;
            if (poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0)
            {
                obj = poolDic[name].GetObj();
            }
            else
            {
                obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
                obj.name = name;
            }

            return obj;
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