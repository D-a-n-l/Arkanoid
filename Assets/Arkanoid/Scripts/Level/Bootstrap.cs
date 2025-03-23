using MiniIT.Core;
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

        private Spawner       spawner = null;

        private Bouncable     ball = null;

        private IInputClicker inputClicker = null;

        private bool          isClicked = false;

        [Inject]
        public void Construct(LevelConfig levelConfig, IInputClicker inputClicker, Bouncable bouncable)
        {
            this.levelConfig = levelConfig;

            this.inputClicker = inputClicker;

            ball = bouncable;
        }

        private void Awake()
        {
            CheckerCountDestroyed checker = new CheckerCountDestroyed(levelConfig);

            spawner = new Spawner(levelConfig, delayBetweenSpawn);

            StartCoroutine(spawner.Start());

            ball.ChangeBodyType(RigidbodyType2D.Kinematic);
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
    }
}