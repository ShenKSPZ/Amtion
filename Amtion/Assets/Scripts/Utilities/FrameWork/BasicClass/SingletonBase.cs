using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// 单例模式基础模块
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public abstract class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
    {
        private static T single = null;

        public static T I()
        {
            if (single != null)
                return single;

            single = FindObjectOfType(typeof(T)) as T;

            if (single == null)
                single = new GameObject("Single " + typeof(T).ToString(), typeof(T)).GetComponent<T>();

            DontDestroyOnLoad(single);

            return single;
        }
    }

    public abstract class SingletonBaseDestory<T> : MonoBehaviour where T : SingletonBaseDestory<T>
    {
        private static T single = null;

        public static T I()
        {
            if(single != null)
                return single;

            single = FindObjectOfType(typeof(T)) as T;

            if (single == null)
                single = new GameObject("Single " + typeof(T).ToString(), typeof(T)).GetComponent<T>();

            return single;
        }
    }
}