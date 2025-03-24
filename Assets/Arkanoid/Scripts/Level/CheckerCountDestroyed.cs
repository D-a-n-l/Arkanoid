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
        }

        #region IDisposable
        public void Dispose()
        {
            CoreEvents.onDestroyedCrashable -= OnCheck;
        }
        #endregion

        private void OnCheck(int value)
        {
            current += value;

            if (current == levelConfig.Crashables.Length)
            {
                current = 0;

                CoreEvents.onAllDestroyedCrashables?.Invoke();
            }
        }
    }
}