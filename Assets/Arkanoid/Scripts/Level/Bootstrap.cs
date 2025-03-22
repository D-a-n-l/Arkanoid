using UnityEngine;
using Zenject;

namespace MiniIT.Level
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject]
        private LevelConfig levelConfig = null;

        private void Awake()
        {
            CheckerCountDestroyed checker = new CheckerCountDestroyed(levelConfig);
        }
    }
}