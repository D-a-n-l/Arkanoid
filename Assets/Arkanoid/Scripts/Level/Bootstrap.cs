using UnityEngine;
using Zenject;

namespace MiniIT.Level
{
    public class Bootstrap : MonoBehaviour
    {
        [Min(0)]
        [SerializeField]
        private float       delayBetweenSpawn = 1f;

        [Inject]
        private LevelConfig levelConfig = null;

        private Spawner     spawner;

        private void Awake()
        {
            CheckerCountDestroyed checker = new CheckerCountDestroyed(levelConfig);

            spawner = new Spawner(levelConfig, delayBetweenSpawn);

            StartCoroutine(spawner.Start());
        }
    }
}