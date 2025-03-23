using System;

namespace MiniIT.Level
{
    public static class CoreEvents
    {
        public static Action      onFalledBall;

        public static Action<int> onDestroyedCrashable;

        public static Action      onAllDestroyedCrashables;
    }
}