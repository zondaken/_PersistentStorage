#nullable enable
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace PersistentStorage.Manager
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T? Instance { get; private set; }
        
        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(transform.gameObject);
            }
            else
            {
                Instance = this as T;
            }
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}