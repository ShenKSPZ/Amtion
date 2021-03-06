using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Framework
{
    /// <summary>
    /// 场景切换模块
    /// </summary>
    public class ScenesMgr : SingletonBase<ScenesMgr>
    {

        /// <summary>
        /// 同步加载场景 容易卡顿 建议使用LoadSceneAsyn
        /// </summary>
        /// <param name="name">场景名称</param>
        /// <param name="function">切换场景后调用的函数，没有请传null</param>
        public void LoadScene(string name, UnityAction function)
        {
            //场景同步加载
            SceneManager.LoadScene(name);

            function?.Invoke(); //function不为空则执行
        }

        /// <summary>
        /// 异步加载场景
        /// </summary>
        /// <param name="name">场景名称</param>
        /// <param name="function">切换场景后调用的函数，没有请传null</param>
        /// /// <param name="ProgressUpdate">切换场景中的加载进度，没有请传null</param>
        public void LoadSceneAsyn(string name, UnityAction function, UnityAction<float> ProgressUpdate)
        {
            StartCoroutine(LoadSceneAsynAction(name, function, ProgressUpdate));
        }

        private IEnumerator LoadSceneAsynAction(string name, UnityAction funtion, UnityAction<float> ProgressUpdate)
        {
            AsyncOperation AO = SceneManager.LoadSceneAsync(name);

            while (!AO.isDone)
            {
                //进度条更新事件
                ProgressUpdate?.Invoke(AO.progress);
                //做一个返回数值，主要用于将下一次循环放到下一帧再执行
                yield return AO.progress;
            }
            funtion?.Invoke(); //function不为空则执行
            yield return AO;
        }
    }

}