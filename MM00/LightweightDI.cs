using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Mixmotion00
{
    public class LightweightDI
    {
        private Dictionary<Type, object> _injectableMap = new Dictionary<Type, object>();

        /// <summary>
        /// Register the class into container map
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        public void Register<T>(T service)
        {
            _injectableMap[typeof(T)] = service;
        }

        /// <summary>
        /// Find the registered map from injectable dict, and return if any found.
        /// </summary>
        /// <returns></returns>
        public T Resolve<T>()
        {
            if (!_injectableMap.ContainsKey(typeof(T)))
            {
                Debug.LogError($"No such class found from container map!");
            }
            return (T)_injectableMap[typeof(T)];
        }

        public void BindDependencies()
        {
            foreach (var kvp in _injectableMap)
            {
                var instance = kvp.Value;
                var instanceType = instance.GetType();
                var fields = instanceType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (var field in fields)
                {
                    var fieldType = field.FieldType;
                    if(_injectableMap.TryGetValue(fieldType, out var dependency))
                    {
                        field.SetValue(instance, dependency);
                    }
                }
            }
        }

        public LightweightDI() { }
    }
}