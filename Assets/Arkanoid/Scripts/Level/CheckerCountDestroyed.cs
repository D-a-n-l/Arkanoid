using System;
using MiniIT.INSTALLERS;

namespace MiniIT.LEVEL
{
    public class CheckerCountDestroyed : IDisposable
    {
        private int current = 0;

        public CheckerCountDestroyed()
        {
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

            if (current == LevelInstaller.CurrentLevel.Crashables.Length)
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