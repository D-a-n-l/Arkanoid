using UnityEngine;
using MiniIT.Presets;
using System.Collections;
using System.Collections.Generic;

namespace MiniIT.Level
{
    public class Spawner
    {
        private LevelConfig      levelConfig = null;

        private WaitForSeconds   wait = new WaitForSeconds(0f);

        private List<GameObject> gameObjects = new List<GameObject>();

        public Spawner(LevelConfig levelConfig, float delayBetweenSpawn)
        {
            this.levelConfig = levelConfig;

            wait = new WaitForSeconds(delayBetweenSpawn);
        }

        public IEnumerator Start()
        {
            foreach (GameObjectPreset crashable in levelConfig.Crashables)
            {
                yield return wait;

                gameObjects.Add(Object.Instantiate(crashable.Prefab, crashable.Position, Quaternion.Euler(crashable.Rotation)));
            }
        }

        public IEnumerator UnloadAll()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] != null)
                {
                    Object.Destroy(gameObjects[i]);
                }
            }

            yield return null;

            gameObjects.Clear();
        }
    }
}