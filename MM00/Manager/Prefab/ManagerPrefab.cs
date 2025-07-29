using UnityEngine;

namespace Mixmotion00
{
    public interface IManagerPrefab
    {
        public T Instantiate<T>(string prefabKey, Transform parent = null) where T : Component;
    }

    public class ManagerPrefab : IManagerPrefab
    {
        public T Instantiate<T>(string prefabKey, Transform parent = null) where T : Component
        {
            var getObj = Resources.Load<Transform>($"PrefabLib/{prefabKey}");
            if (getObj == null) Debug.LogError($"No prefab found in MMOO>Manager>Prefab>Resources>PrefabLib with key {prefabKey}");
            if (getObj.GetComponent<T>() == null) Debug.LogError($"No component of type {typeof(T).Name} exist!");


            var go = GameObject.Instantiate(getObj, parent);
            return go.GetComponent<T>();
        }
    }
}