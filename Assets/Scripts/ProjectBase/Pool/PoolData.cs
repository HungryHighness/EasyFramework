using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ProjectBase.Pool
{
    public class PoolData
    {
        public GameObject fatherOBj;

        public List<GameObject> poolList;

        public PoolData(GameObject obj, GameObject poolOBj)
        {
            fatherOBj = new GameObject(obj.name);
            fatherOBj.transform.parent = poolOBj.transform;

            poolList = new List<GameObject>();
            PushObj(obj);
        }

        public GameObject GetObj()
        {
            GameObject obj = null;
            obj = poolList[0];
            poolList.RemoveAt(0);
            obj.transform.parent = null;
            obj.SetActive(true);
            return obj;
        }

        public void PushObj(GameObject obj)
        {
            poolList.Add(obj);
            obj.transform.parent = fatherOBj.transform;
            obj.SetActive(false);
        }
    }
}