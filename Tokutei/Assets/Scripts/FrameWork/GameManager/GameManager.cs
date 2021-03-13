using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Framework
{

    public enum GameState
    {
        GamePlay,
        InGameMenu,
        Menu,
    }

    public class GameManager : SingletonBase<GameManager>
    {
        public Coroutine SlowTimeCoroutine;
        [HideInInspector]
        public float FixedDeltaTime;
        [HideInInspector]
        public bool SlowTiming;

        public bool FindingScripts = false;

        [Reorderable]
        public List<GameScripts> AwakeScripts = new List<GameScripts>();
        [Reorderable]
        public List<GameScripts> StartScripts = new List<GameScripts>();
        [Reorderable]
        public List<GameScripts> UpdateScripts = new List<GameScripts>();
        [Reorderable]
        public List<GameScripts> FixedUpdateScripts = new List<GameScripts>();
        [Reorderable]
        public List<GameScripts> LateUpdateScripts = new List<GameScripts>();

        void Awake()
        {
            FixedDeltaTime = Time.fixedDeltaTime;
            if(FindingScripts)
            {
                AwakeScripts = FindObjectsOfType<GameScripts>().ToList();
                StartScripts = FindObjectsOfType<GameScripts>().ToList();
                UpdateScripts = FindObjectsOfType<GameScripts>().ToList();
                FixedUpdateScripts = FindObjectsOfType<GameScripts>().ToList();
                LateUpdateScripts = FindObjectsOfType<GameScripts>().ToList();
            }

            for (int i = 0; i < AwakeScripts.Count; i++)
            {
                AwakeScripts[i].s_Awake();
            }
        }

        void Start()
        {
            for (int i = 0; i < AwakeScripts.Count; i++)
            {
                AwakeScripts[i].s_Start();
            }
        }

        void Update()
        {
            for (int i = 0; i < AwakeScripts.Count; i++)
            {
                AwakeScripts[i].s_Update();
            }
        }

        void FixedUpdate()
        {
            for (int i = 0; i < AwakeScripts.Count; i++)
            {
                AwakeScripts[i].s_FixedUpdate();
            }
        }

        void LateUpdate()
        {
            for (int i = 0; i < AwakeScripts.Count; i++)
            {
                AwakeScripts[i].s_LateUpdate();
            }
        }

        public void DebugSlowDown()
        {
            if(Time.timeScale != 1)
            {
                SetSlowTime(1f);
            }
            else
            {
                SetSlowTime(0.3f);
            }
        }

        public void SetSlowTime(float SlowTime, float SlowScale)
        {
            if (SlowTimeCoroutine == null)
                SlowTimeCoroutine = StartCoroutine(SetSlowTimeCoro_Time(SlowTime, SlowScale));
            else
            {
                StopCoroutine(SlowTimeCoroutine);
                Time.timeScale = 1;
                Time.fixedDeltaTime = FixedDeltaTime * Time.timeScale;
                SlowTimeCoroutine = StartCoroutine(SetSlowTimeCoro_Time(SlowTime, SlowScale));
            }
        }

        public void SetSlowTime(float SlowScale)
        {
            if (SlowTimeCoroutine == null)
                SlowTimeCoroutine = StartCoroutine(SetSlowTime_Default(SlowScale));
            else
            {
                StopCoroutine(SlowTimeCoroutine);
                Time.timeScale = 1;
                Time.fixedDeltaTime = FixedDeltaTime * Time.timeScale;
                SlowTimeCoroutine = StartCoroutine(SetSlowTime_Default(SlowScale));
            }
        }

        public void SetSlowTimeOneShot(float SlowTime, float SlowScale)
        {
            SetSlowTimeCoro_OneShot(SlowTime, SlowScale);
        }

        IEnumerator SetSlowTimeCoro_Time(float SlowTime, float SlowScale)
        {
            SlowTiming = true;
            Time.timeScale = SlowScale;
            Time.fixedDeltaTime = FixedDeltaTime * Time.timeScale;
            yield return new WaitForSecondsRealtime(SlowTime);
            Time.timeScale = 1;
            Time.fixedDeltaTime = FixedDeltaTime * Time.timeScale;
            SlowTiming = false;
        }

        IEnumerator SetSlowTime_Default(float SlowScale)
        {
            Time.timeScale = SlowScale;
            Time.fixedDeltaTime = FixedDeltaTime * Time.timeScale;
            if (SlowScale != 1)
                SlowTiming = true;
            else
                SlowTiming = false;
            yield return null;
        }

        IEnumerator SetSlowTimeCoro_OneShot(float SlowTime, float SlowScale)
        {
            bool IsSlowTiming = SlowTiming;
            float scale = Time.timeScale;
            Time.timeScale = SlowScale;
            Time.fixedDeltaTime = FixedDeltaTime * Time.timeScale;
            yield return new WaitForSecondsRealtime(SlowTime);
            if (IsSlowTiming == SlowTiming)
            {
                Time.timeScale = scale;
                Time.fixedDeltaTime = FixedDeltaTime * Time.timeScale;
            }
        }
    }

}