using System;
using UnityEngine;

namespace QueueGame
{
    public class SingletonManager<T>
        : MonoBehaviour where T : SingletonManager<T>
    {
        public static T Instance { get; private set; }
        public static bool Exists => Instance != null;

        protected virtual void Awake()
        {
            if (Exists)
                throw new InvalidOperationException($"singleton manager instance already exists: {typeof(T).Name}");

            Instance = (T)this;
        }
    }
}
