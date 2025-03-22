using MiniIT.Core;
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

        [Inject]
        private Bouncable ball;

        private bool isClick = false;

        private void Awake()
        {
            CheckerCountDestroyed checker = new CheckerCountDestroyed(levelConfig);

            spawner = new Spawner(levelConfig, delayBetweenSpawn);

            StartCoroutine(spawner.Start());

            ball.ChangeBodyType(RigidbodyType2D.Kinematic);
        }

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0) && isClick == false)
            {
                isClick = true;

                ball.ChangeBodyType(RigidbodyType2D.Dynamic);

                ball.transform.SetParent(null);
            }
        }
    }
}