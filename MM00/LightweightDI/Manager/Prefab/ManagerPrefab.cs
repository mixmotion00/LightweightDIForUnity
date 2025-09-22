using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace Mixmotion00
{
    public interface IManagerPrefab
    {
        public void Init(LightweightDI di);
        public T Instantiate<T>(string prefabKey, Transform parent = null, bool autoResolveDependency = true) where T : Component;
    }

    public class ManagerPrefab : IManagerPrefab
    {
        private LightweightDI _di;

        public void Init(LightweightDI di) 
        {
            _di = di;
        }

        private void InjectDependency<T>(T comp) 
        {
            var type = comp.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                var fieldType = field.FieldType;
                if (_di.InjectableMap.TryGetValue(fieldType, out var dependency))
                {
                    field.SetValue(comp, dependency);
                }
            }
        }

        public T Instantiate<T>(string prefabKey, Transform parent = null, bool autoResolveDependency = true) where T : Component
        {
            var getObj = Resources.Load<Transform>($"PrefabLib/{prefabKey}");
            if (getObj == null) Debug.LogError($"No prefab found in MMOO>Manager>Prefab>Resources>PrefabLib with key {prefabKey}");
            if (getObj.GetComponent<T>() == null) Debug.LogError($"No component of type {typeof(T).Name} exist!");

            var go = GameObject.Instantiate(getObj, parent);
            var component = go.GetComponent<T>();
            
            if(autoResolveDependency)InjectDependency(component);

            return component;
        }
    }
}