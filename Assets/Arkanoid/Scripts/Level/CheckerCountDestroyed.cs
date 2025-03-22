using System;
using UnityEngine;

namespace MiniIT.Level
{
    public class CheckerCountDestroyed : IDisposable
    {
        private LevelConfig levelConfig = null;

        private int current = 0;

        public CheckerCountDestroyed(LevelConfig levelConfig)
        {
            this.levelConfig = levelConfig;

            CrashableEvent.onDestroyed += OnCheck;
        }

        #region IDisposable
        public void Dispose()
        {
            CrashableEvent.onDestroyed -= OnCheck;
        }
        #endregion

        private void OnCheck(int value)
        {
            current += value;

            if (current == levelConfig.Crashables.Length)
            {
                Debug.Log("Win");
            }
        }
    }
}