using MiniIT.Core;
using MiniIT.Installers;
using System.Collections;
using UnityEngine;
using Zenject;

namespace MiniIT.Level
{
    public class Bootstrap : MonoBehaviour
    {
        [Min(0)]
        [SerializeField]
        private float           delayBetweenSpawn = 1f;

        [Space(10)]
        [SerializeField]
        private Canvas          canvasWin = null;

        [SerializeField]
        private Canvas          canvasLose = null;

        private AllLevelsConfig allLevels = null;

        private Movable         platform = null;

        private Bouncable       ball = null;

        private Spawner         spawner = null;

        private IInputClicker   inputClicker = null;

        private bool            isClicked = true;

        [Inject]
        public void Construct(AllLevelsConfig allLevels, IInputClicker inputClicker, Movable movable, Bouncable bouncable)
        {
            this.allLevels = allLevels;

            this.inputClicker = inputClicker;

            platform = movable;

            ball = bouncable;

            CheckerCountDestroyed checker = new CheckerCountDestroyed(LevelInstaller.CurrentLevel);

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
            canvasWin.enabled = false;

            canvasLose.enabled = false;

            StartCoroutine(StartGameCoroutine());
        }

        private IEnumerator StartGameCoroutine()
        {
            spawner = new Spawner(LevelInstaller.CurrentLevel, delayBetweenSpawn);

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
            yield return StartCoroutine(spawner.UnloadAll());

            ball.OnZeroingVelocity();

            ball.transform.position = LevelInstaller.CurrentLevel.Ball.Position;

            ball.transform.SetParent(platform.transform, false);

            yield return StartCoroutine(StartGameCoroutine());
        }

        public void NextLevel()
        {
            CoreEvents.onFalledBall += Lose;

            LevelInstaller.RandomLevel(allLevels);

            RestartGame();
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

        public void Win()
        {
            canvasWin.enabled = true;

            CoreEvents.onFalledBall -= Lose;
        }

        public void Lose()
        {
            canvasLose.enabled = true;
        }
    }
}