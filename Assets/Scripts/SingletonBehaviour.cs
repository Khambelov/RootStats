using System;
using UnityEngine;

namespace RootStats.Core
{
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                throw new Exception($"{typeof(T).Name} not initialized");
            }
        }

        public static void Init()
        {
            CreateInstance();
            _instance.OnInit();
        }

        private static void CreateInstance()
        {
            if (IsInitialized())
                throw new Exception($"{typeof(T).Name} already initialized");

            var gameObject = new GameObject(typeof(T).Name);
            _instance = gameObject.AddComponent<T>();
        }

        public static bool IsInitialized()
        {
            return _instance != null;
        }

        protected abstract void OnInit();

        protected virtual void OnDestroy()
        {
            _instance = null;
        }
    }
}