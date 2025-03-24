using System;

namespace MiniIT.Level
{
    public class CheckerCountDestroyed : IDisposable
    {
        private LevelConfig levelConfig = null;

        private int current = 0;

        public CheckerCountDestroyed(LevelConfig levelConfig)
        {
            this.levelConfig = levelConfig;

            CoreEvents.onDestroyedCrashable += OnCheck;

            CoreEvents.onFalledBall += OnZeroing;
        }

        #region IDisposable
        public void Dispose()
        {
            CoreEvents.onDestroyedCrashable -= OnCheck;

            CoreEvents.onFalledBall -= OnZeroing;
        }
        #endregion

        private void OnCheck(int value)
        {
            current += value;

            if (current == levelConfig.Crashables.Length)
            {
                OnZeroing();

                CoreEvents.onAllDestroyedCrashables?.Invoke();
            }
        }

        private void OnZeroing()
        {
            current = 0;
        }
    }
}