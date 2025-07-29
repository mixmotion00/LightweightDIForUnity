using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

namespace Mixmotion00
{
    public class LightweightDI
    {
        private Dictionary<Type, object> _injectableMap = new Dictionary<Type, object>();

        public Dictionary<Type, object> InjectableMap { get => _injectableMap; set => _injectableMap = value; }

        /// <summary>
        /// Register the class into container map
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        public void Register<T>(T service)
        {
            InjectableMap[typeof(T)] = service;
        }

        /// <summary>
        /// Find the registered map from injectable dict, and return if any found.
        /// </summary>
        /// <returns></returns>
        public T Resolve<T>()
        {
            if (!InjectableMap.ContainsKey(typeof(T)))
            {
                Debug.LogError($"No such class found from container map!");
            }
            return (T)InjectableMap[typeof(T)];
        }

        public IEnumerable<T> GetInjectClassess<T>() where T : class
        {
            return InjectableMap.
                Where(kv => typeof(T).IsAssignableFrom(kv.Key))
                .Select(kv => kv.Value).
                Cast<T>();
        }

        public void BindDependencies()
        {
            foreach (var kvp in InjectableMap)
            {
                var instance = kvp.Value;
                var instanceType = instance.GetType();
                var fields = instanceType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (var field in fields)
                {
                    var fieldType = field.FieldType;
                    if (InjectableMap.TryGetValue(fieldType, out var dependency))
                    {
                        field.SetValue(instance, dependency);
                    }
                }
            }
        }

        public LightweightDI() { }
    }
}
