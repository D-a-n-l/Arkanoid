using MiniIT.Core;
using System.Collections;
using UnityEngine;
using Zenject;

namespace MiniIT.Level
{
    public class Bootstrap : MonoBehaviour
    {
        [Min(0)]
        [SerializeField]
        private float         delayBetweenSpawn = 1f;

        private LevelConfig   levelConfig = null;

        private Movable       platform = null;

        private Bouncable     ball = null;

        private Spawner       spawner = null;

        private IInputClicker inputClicker = null;

        private bool          isClicked = true;

        [Inject]
        public void Construct(LevelConfig levelConfig, IInputClicker inputClicker, Movable movable, Bouncable bouncable)
        {
            this.levelConfig = levelConfig;

            this.inputClicker = inputClicker;

            platform = movable;

            ball = bouncable;

            CheckerCountDestroyed checker = new CheckerCountDestroyed(levelConfig);

            CoreEvents.onAllDestroyedCrashables += Win;

            CoreEvents.onFalledBall += Lose;
        }

        private void OnDisable()
        {
            CoreEvents.onAllDestroyedCrashables -= Win;

            CoreEvents.onFalledBall -= Lose;
        }

        private void Start()
        {
            StartCoroutine(StartGameCoroutine());
        }

        private IEnumerator StartGameCoroutine()
        {
            spawner = new Spawner(levelConfig, delayBetweenSpawn);

            ball.ChangeBodyType(RigidbodyType2D.Kinematic);

            yield return StartCoroutine(spawner.Start());

            isClicked = false;
        }

        public void RestartGame()
        {
            StartCoroutine(RestartGameCoroutine());
        }

        private IEnumerator RestartGameCoroutine()
        {
            ball.transform.SetParent(platform.transform);

            yield return StartCoroutine(StartGameCoroutine());
        }

        private void Update()
        {
            if (isClicked == false && inputClicker.OnClicked() == true)
            {
                isClicked = true;

                ball.transform.SetParent(null);

                ball.ChangeBodyType(RigidbodyType2D.Dynamic);
            }
        }

        public void Lose()
        {
            Debug.Log("Loseeee");
        }

        public void Win()
        {
            Debug.Log("Wiiinnn");
        }
    }
}