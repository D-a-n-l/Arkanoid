using System.Collections;
using UnityEngine;

namespace MiniIT.Level
{
    public class Spawner
    {
        private LevelConfig    levelConfig = null;

        private WaitForSeconds wait = new WaitForSeconds(0f);

        public Spawner(LevelConfig levelConfig, float delayBetweenSpawn)
        {
            this.levelConfig = levelConfig;

            wait = new WaitForSeconds(delayBetweenSpawn);
        }

        public IEnumerator Start()
        {
            foreach (CrashablePreset crashable in levelConfig.Crashables)
            {
                yield return wait;

                Object.Instantiate(crashable.Prefab, crashable.Position, Quaternion.Euler(crashable.Rotation));
            }
        }
    }
}